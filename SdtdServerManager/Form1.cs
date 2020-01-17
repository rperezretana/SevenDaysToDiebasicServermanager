using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Xml;
using System.IO;
using System.Threading;

namespace SdtdServerManager
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.OpenFileDialog fileDialog;
        private Configuration Configuration { get; set; }
        public Form1()
        {
            InitializeComponent();
            fileDialog = new OpenFileDialog();
            ConsolePrint("Reading the file");
            Configuration = FileSaver.ReadFromJsonFile<Configuration>("Configuration.json");
            serverIp.Text = Configuration.TelnetIp ?? "192.168.1.2"; //ip example
            numericUpDown1.Value = Configuration.RestartEveryHours > 0 ? Configuration.RestartEveryHours : 12;
            UpdateStatusOfList();
            timer_30SecondsTimer.Start();
            timer2.Start();
            timer_OneMinuteTimer.Start();

            foreach (var item in Configuration.ServerItems)
            {
                //It seems that this application just started so we think next restart should be in X hours.
                if (item.LastRestart < DateTime.Now.AddMinutes(-1))
                {
                    item.LastRestart = DateTime.Now;
                    item.NextRestart = DateTime.Now.AddHours((int)numericUpDown1.Value);
                }
            }
            ShutingDown = new HashSet<string>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fileDialog.ShowDialog();
            var file = fileDialog.FileName;
            if (listBox1.Items.Contains(file) && file!=null && file.ToLower().EndsWith("7daystodieserver.exe"))
            {
                MessageBox.Show("The server is already in the list or is not a valid 7DaysToDieServer.exe");
                return;
            }
            listBox1.Items.Add(file);
            Configuration.ServerItems.Add(new ServerItem() {
                ServerNamePath = file,
                TelnetConnection = GetTelNetCredentialsByPath(file)
            });
            UpdateStatusOfList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex >= 0)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
                Configuration.ServerItems.RemoveAt(listBox1.SelectedIndex);
                UpdateStatusOfList();
            }
        }

        private void RunApplication(string applicationPath, bool killItIfRunning)
        {
            //startdedicated.bat
            Process[] pname = Process.GetProcessesByName("7DaysToDieServer");
            var path = applicationPath.Substring(0, applicationPath.LastIndexOf("\\"));

            foreach (var p in pname)
            {
                if(p.MainModule.FileName == applicationPath)
                {
                    if (killItIfRunning == false)
                    {
                        ConsolePrint($"The server [{applicationPath}] is already running.");
                        return;
                    }
                    else
                    {
                        ConsolePrint($"Killing Application [{applicationPath}]");
                        p.Kill();
                    }
                }
            }

            var processStartInfo = new ProcessStartInfo
            {
                WorkingDirectory = path,
                FileName = path + "\\startdedicated.bat"
            };
            var all = File.ReadAllLines(path + "\\startdedicated.bat");
            if (all.Any(l => l == "pause"))
            {
                File.WriteAllText(path + "\\startdedicated.bat", File.ReadAllText(path + "\\startdedicated.bat").Replace("pause",""));
            }
            Process.Start(processStartInfo);
        }

        private void SendTelNetCommand(string pathServer, string command)
        {

        }

        private TelnetConnection GetTelNetCredentialsByPath(string serverPath)
        {
            ConsolePrint($"Loading credentials to telnet for {serverPath}");
            var path = serverPath.Substring(0, serverPath.LastIndexOf("\\"));
            path = path + "\\serverconfig.xml";
            string port = "0", password;

            if(!System.IO.File.Exists(path))
            {
                MessageBox.Show($"Cant find the configuration file at [{path}]");
                ConsolePrint($"Cant find the configuration file at [{path}]");
                return null;
            }
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            foreach(XmlNode property in doc.DocumentElement.ChildNodes)
            {
                if (property.Attributes == null)
                    continue;

                if(property.Attributes["name"].Value == "TelnetPort")
                {
                    port = property.Attributes["value"].Value;
                }
                else if (property.Attributes["name"].Value == "TelnetPassword")
                {
                    password = property.Attributes["value"].Value;
                }
                //TelnetPort
                //TelnetPassword
            }
            var client = new TelnetConnection(serverIp.Text, int.Parse(port));
            if (client.IsConnected)
            {
                client.WriteLine("MesopotamiaTestosterona2");//password
                ConsolePrint($"Telnet Console Connected for {serverPath}");
            }
            else
            {
                ConsolePrint($"FAILED Telnet Console connection for {serverPath}");
            }
            return client;
        }

        private void UpdateStatusOfList()
        {

            Process[] pname = Process.GetProcessesByName("7DaysToDieServer");

            listBox2.Items.Clear();
            listBox1.Items.Clear();

            foreach (var item in Configuration.ServerItems)
            {
                try
                {
                    var result = "";
                    if (item.TelnetConnection.IsConnected)
                    {
                        result += "Telnet: OK. ";
                    }
                    else
                    {
                        result += "Telnet: NO. ";
                        item.TelnetConnection = GetTelNetCredentialsByPath(item.ServerNamePath);
                    }

                    if (pname.Any(p => p.MainModule.FileName == item.ServerNamePath))
                    {
                        result += "Running: Yes. ";
                    }
                    else
                    {
                        result += "Running: No. ";
                        item.IsItRunning = false;
                        if (checkBox5.Checked)
                        {
                            ConsolePrint("Server Crashed/closed, requesting restart and schedule restart.");
                            item.LastRestart = DateTime.Now;
                            item.NextRestart = DateTime.Now.AddHours((int)numericUpDown1.Value);
                            ShutingDown.Remove(item.ServerNamePath);
                            RunApplication(item.ServerNamePath, true);
                        }
                    }
                    var span = item.NextRestart - DateTime.Now;
                    result += $"Next restart: {(int)span.TotalHours} h {(int)span.Minutes} minutes. ";

                    listBox2.Items.Add(result);
                    listBox1.Items.Add(item.ServerNamePath);
                    if (item.TelnetConnection.IsConnected)
                    {
                        ConsolePrint(item.TelnetConnection.Read());
                    }
                }
                catch (Exception) { }
            }
            FileSaver.WriteToJsonFile<Configuration>("Configuration.json", Configuration);
        }

        private void ConsolePrint(string message)
        {
            if (message == null || message.Length == 0)
                return;

            consoleTextArea.Text += Environment.NewLine + $" {DateTime.Now.ToLongTimeString()}> {message}";
            consoleTextArea.SelectionStart = consoleTextArea.Text.Length;
            consoleTextArea.ScrollToCaret();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdateStatusOfList();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateStatusOfList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RestartAllServersNow();
        }


        HashSet<string> ShutingDown;
        private void CheckRestartTimes()
        {

            foreach (var item in Configuration.ServerItems)
            {
                var minFromNow = MinutesFromNow(item.NextRestart);

                if (ShutingDown.Contains(item.ServerNamePath))
                {
                    if (cbxKillApplication.Checked && minFromNow < -1)
                    {
                        ConsolePrint($"Requested shutdown {minFromNow} minutes ago, I should kill it by force now.");
                        try
                        {
                            ConsolePrint("Killing applications by force...");
                            Process[] pname = Process.GetProcessesByName("7DaysToDieServer");
                            var proc = pname.FirstOrDefault(p => p.MainModule.FileName == item.ServerNamePath);
                            if (proc != null)
                            {
                                proc.Kill();
                            }
                            ShutingDown.Remove(item.ServerNamePath);
                            item.LastRestart = DateTime.Now;
                            item.NextRestart = DateTime.Now.AddHours((int)numericUpDown1.Value);
                        }
                        catch (Exception e) { ConsolePrint("Failed when killing it, Application no longer running? "+ e.Message); }
                    }
                    continue;
                }

                if (minFromNow == 60)
                {
                    item.TelnetConnection.SendTextMessageToSdtdServer("[ff0000]Server is restarting in 60 minutes...[ffffff]");
                }
                else if (minFromNow == 30)
                {
                    item.TelnetConnection.SendTextMessageToSdtdServer("[ff0000]Server is restarting in 30 minutes...[ffffff]");
                }
                else if (minFromNow == 10)
                {
                    item.TelnetConnection.SendTextMessageToSdtdServer("[ff0000]Server is restarting in 10 minutes...[ffffff]");
                }
                else if (minFromNow <= 5 && minFromNow > 0)
                {
                    item.TelnetConnection.SendTextMessageToSdtdServer($"[ff0000]Server is restarting in {MinutesFromNow(item.NextRestart)} minutes...[ffffff]");
                    if(minFromNow == 2)
                        item.TelnetConnection.Write("saveworld\n");
                }
                else if (minFromNow <= 0)
                {
                    ShutingDown.Add(item.ServerNamePath);
                    item.TelnetConnection.SendTextMessageToSdtdServer("[ff0000]Server is restarting now...[ffffff]");
                    ConsolePrint("Requesting restart by shutdown...");
                    item.TelnetConnection.Write("shutdown\n");
                }
            }
        }

        private void RestartAllServersNow()
        {
            ConsolePrint("Requesting restart by shutdown...");
            foreach (var item in Configuration.ServerItems)
            {
                try
                {
                    item.TelnetConnection.Write("saveworld\n");
                    item.TelnetConnection.SendTextMessageToSdtdServer("[ff0000]Server is restarting now...[ffffff]");
                    Thread.Sleep(5000);
                    item.TelnetConnection.Write("shutdown\n");
                }
                catch (Exception) { }
            }
            Thread.Sleep(15000);

            if (!cbxKillApplication.Checked)
                return;

            ConsolePrint("Killing applications by force...");
            Process[] pname = Process.GetProcessesByName("7DaysToDieServer");
            foreach (var item in Configuration.ServerItems)
            {
                var proc = pname.FirstOrDefault(p => p.MainModule.FileName == item.ServerNamePath);
                if (proc != null)
                {
                    proc.Kill();
                }

                ShutingDown.Remove(item.ServerNamePath);
                item.LastRestart = DateTime.Now;
                item.NextRestart = DateTime.Now.AddHours((int)numericUpDown1.Value);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private int MinutesFromNow(DateTime to)
        {
            return (int)(to - DateTime.Now).TotalMinutes;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Configuration.RestartEveryHours = numericUpDown1.Value;
            foreach (var item in Configuration.ServerItems)
            {
                //It seems that this application just started so we think next restart should be in X hours.
                item.NextRestart = item.LastRestart.AddHours((int)numericUpDown1.Value);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (var item in Configuration.ServerItems)
            {
                item.TelnetConnection.SendTextMessageToSdtdServer("[ff0000]Welcome![ffffff] Server restarts every 12 hours to keep it running smoothly.");
            }
        }

        private void CountPlayers() {
            foreach (var item in Configuration.ServerItems)
            {
                try
                {
                    if (item.TelnetConnection.IsConnected)
                    {
                        item.TelnetConnection.WriteLine("lp");
                        ConsolePrint($"{item.ServerNamePath} ");
                        ConsolePrint(item.TelnetConnection.Read());
                    }
                }
                catch (Exception) {
                    ConsolePrint("Could not determine if the server was online or the number of players active.");
                }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            CountPlayers();
            CheckRestartTimes();
        }
    }
}
