namespace SdtdServerManager
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.serverIp = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxKillApplication = new System.Windows.Forms.CheckBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.consoleTextArea = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.timer_30SecondsTimer = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.timer_OneMinuteTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 64);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(594, 355);
            this.listBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(145, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add Server";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox5);
            this.groupBox1.Controls.Add(this.serverIp);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbxKillApplication);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(1091, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(446, 133);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(9, 20);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(162, 17);
            this.checkBox5.TabIndex = 12;
            this.checkBox5.Text = "Restart if the server crashed.";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // serverIp
            // 
            this.serverIp.Location = new System.Drawing.Point(207, 96);
            this.serverIp.Name = "serverIp";
            this.serverIp.Size = new System.Drawing.Size(100, 20);
            this.serverIp.TabIndex = 10;
            this.serverIp.Text = "192.168.1.3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(195, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Your server IP for TELNET connections";
            // 
            // cbxKillApplication
            // 
            this.cbxKillApplication.AutoSize = true;
            this.cbxKillApplication.Location = new System.Drawing.Point(9, 66);
            this.cbxKillApplication.Name = "cbxKillApplication";
            this.cbxKillApplication.Size = new System.Drawing.Size(430, 17);
            this.cbxKillApplication.TabIndex = 3;
            this.cbxKillApplication.Text = "Force a kill on all the 7DaysToDieServer.exe proccess before starting a new insta" +
    "nce.";
            this.cbxKillApplication.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(115, 40);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(41, 20);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Restart servers every                  hours";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox4);
            this.groupBox2.Controls.Add(this.checkBox3);
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Location = new System.Drawing.Point(1091, 203);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(446, 100);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chats Interaction - not implemented yet - ";
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(6, 65);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(221, 17);
            this.checkBox4.TabIndex = 2;
            this.checkBox4.Text = "Alert on Discord when server is restarting.";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(6, 42);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(203, 17);
            this.checkBox3.TabIndex = 1;
            this.checkBox3.Text = "Alert on Twitch when user join server.";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(6, 19);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(207, 17);
            this.checkBox2.TabIndex = 0;
            this.checkBox2.Text = "Alert on Discord when user join server.";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1091, 321);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(205, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Stop all Servers and reset timers";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 22);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(127, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Remove Server";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(612, 64);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(461, 355);
            this.listBox2.TabIndex = 7;
            // 
            // consoleTextArea
            // 
            this.consoleTextArea.BackColor = System.Drawing.SystemColors.MenuText;
            this.consoleTextArea.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consoleTextArea.ForeColor = System.Drawing.SystemColors.Window;
            this.consoleTextArea.Location = new System.Drawing.Point(12, 446);
            this.consoleTextArea.Multiline = true;
            this.consoleTextArea.Name = "consoleTextArea";
            this.consoleTextArea.Size = new System.Drawing.Size(1525, 434);
            this.consoleTextArea.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 427);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Console";
            // 
            // timer_30SecondsTimer
            // 
            this.timer_30SecondsTimer.Enabled = true;
            this.timer_30SecondsTimer.Interval = 30000;
            this.timer_30SecondsTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(257, 22);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(194, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "Send Test Messges To Servers";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // timer_OneMinuteTimer
            // 
            this.timer_OneMinuteTimer.Interval = 60000;
            this.timer_OneMinuteTimer.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1559, 904);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.consoleTextArea);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "7Dtd Server manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbxKillApplication;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.TextBox consoleTextArea;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox serverIp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timer_30SecondsTimer;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Timer timer_OneMinuteTimer;
    }
}

