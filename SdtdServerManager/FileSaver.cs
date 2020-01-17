using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace SdtdServerManager
{

    public class FileSaver
    {
        /// <summary>
        /// Writes the given object instance to a Json file.
        /// <para>Object type must have a parameterless constructor.</para>
        /// <para>Only Public properties and variables will be written to the file. These can be any type though, even other classes.</para>
        /// <para>If there are public properties/variables that you do not want written to the file, decorate them with the [JsonIgnore] attribute.</para>
        /// </summary>
        /// <typeparam name="T">The type of object being written to the file.</typeparam>
        /// <param name="filePath">The file path to write the object instance to.</param>
        /// <param name="objectToWrite">The object instance to write to the file.</param>
        /// <param name="append">If false the file will be overwritten if it already exists. If true the contents will be appended to the file.</param>
        public static void WriteToJsonFile<T>(string filePath, T objectToWrite) where T : new()
        {
            TextWriter writer = null;
            try
            {
                var contentsToWriteToFile = JsonConvert.SerializeObject(objectToWrite);
                writer = new StreamWriter(filePath, false);
                writer.Write(contentsToWriteToFile);
            }
            finally
            {
                writer?.Close();
            }
        }

        /// <summary>
        /// Reads an object instance from an Json file.
        /// <para>Object type must have a parameterless constructor.</para>
        /// </summary>
        /// <typeparam name="T">The type of object to read from the file.</typeparam>
        /// <param name="filePath">The file path to read the object instance from.</param>
        /// <returns>Returns a new instance of the object read from the Json file.</returns>
        public static T ReadFromJsonFile<T>(string filePath) where T : new()
        {
            if (!File.Exists(filePath))
                return new T();

            using (FileStream sr = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(sr))
                {
                    using (JsonReader jsReader = new JsonTextReader(reader))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        return serializer.Deserialize<T>(jsReader);
                    }
                }
            }

            //TextReader reader = null;
            //try
            //{
            //    reader = new StreamReader(filePath);
            //    var fileContents = reader.ReadToEnd();
            //    return JsonConvert.DeserializeObject<T>(fileContents);
            //}
            //finally
            //{
            //    if (reader != null)
            //        reader.Close();
            //}
        }

        private static readonly Random RandomInstance = new Random();


        public static bool WriteToJsonFileFromTimeToTime<T>(string filePath, T objectToWrite, int outOfTenTimes)
            where T : new()
        {
            if (outOfTenTimes >= 10)
                throw new Exception($"The intention is to save the file {outOfTenTimes} times out of 10 times? That does not sound right. " +
                                    $"Adjust that number or just save all the time.");
            var result = 0;
            lock (RandomInstance) // synchronize
            {
                result = RandomInstance.Next(1, 10);
            }

            if (result == outOfTenTimes)
            {
                Console.WriteLine($@"Saving file {filePath}.");
                WriteToJsonFile<T>(filePath, objectToWrite);
                return true;
            }
            return false;
        }

    }

}
