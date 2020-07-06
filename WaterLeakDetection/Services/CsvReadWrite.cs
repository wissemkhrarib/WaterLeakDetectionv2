using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WaterLeakDetection.Data.Modals;

namespace WaterLeakDetection.Services
{
    public class CsvReadWrite
    {
        public static async Task AsyncWriteSensorsState(string fileName,IEnumerable<Sensor> sensors)
        {
            try
            {
                using (StreamWriter writer = File.CreateText(fileName))
                {
                    foreach (var sensor in sensors)
                    {
                        await writer.WriteLineAsync(sensor.Id + "," + (sensor.IsOn ? 1 : 0));
                    }
                    writer.Close();
                }
            }
            catch { }
        }
        public static async Task AsyncWriteSensorsLevel(string fileName, IEnumerable<Sensor> sensors)
        {
            while (true)
            {
                try
                {
                    using (StreamWriter writer = File.CreateText(fileName))
                    {
                        Random rnd = new Random();
                        foreach (var sensor in sensors)
                        {
                            int a = rnd.Next(300);
                            await writer.WriteLineAsync(sensor.Id + "," + a);
                        }
                        writer.Close();
                    }
                    Thread.Sleep(6000);
                }
                catch { }
            }
        }
        public static IEnumerable<Sensor> ReadSensorsLevel(string fileName)
        {
            List<Sensor> sensors = new List<Sensor>();
            try
            {
                using (TextReader reader = File.OpenText(fileName))
                {
                    string line = reader.ReadToEnd();
                    string[] lines = line.Split("\r\n");
                    for (int i = 0; i < lines.Length - 1; i++)
                    {
                        string[] sensorFields = lines[i].Split(",");
                        var sensor = new Sensor { Id = int.Parse(sensorFields[0]), CurrentLevel = int.Parse(sensorFields[1]) };
                        sensors.Add(sensor);
                    }
                    reader.Close();
                    return sensors;

                }
            }
            catch
            {
                return sensors;
            }

        }
    }
}
