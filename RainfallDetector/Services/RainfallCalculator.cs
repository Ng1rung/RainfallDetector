using CsvHelper;
using RainfallDetector.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RainfallDetector.Services
{
    public  class RainfallCalculator : IRainfallCalculator
    {
        public RainfallCalculator()
        {
            
        }

        /// <summary>
        /// Extract the data from CSV file.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public List<T> ReadCsv<T>(string filePath)
        {
            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            var records = new List<T>();
            records = csv.GetRecords<T>().ToList();
            return records;
        }


        /// <summary>
        /// Calculate the average of the data
        /// </summary>
        /// <param name="rainfallDatas"></param>
        /// <returns></returns>
        public int GetAverage(List<RainfallData> rainfallDatas)
        {
            int sum = (rainfallDatas.Select(x => x.Measurement).Sum());
            int total =  rainfallDatas.Count();
            return sum/total;
        }

        /// <summary>
        /// Find the trend of rainfall from last 2 recording
        /// </summary>
        /// <param name="rainfallDatas"></param>
        /// <returns></returns>
        public string GetTrend(List<RainfallData> rainfallDatas)
        {
            List<RainfallData> thisList = rainfallDatas.OrderBy(x => x.DateTime).ToList();
            if (thisList.Count >= 2) {
                if (thisList[0].Measurement < thisList[1].Measurement)
                {
                    return "Increasing";
                }
                else
                {
                    return "Decreasing";
                }
            }
            return "NA";
        }


        /// <summary>
        /// Main process of Rainfall calculation 
        /// </summary>
        /// <param name="filePaths"></param>
        public void Get(List<string> filePaths)
        {
            List<RainfallData> rainfallDatas = new List<RainfallData>();
            List<Devices> devices = new List<Devices>();

            string? folderPath = Directory.GetParent(Environment.CurrentDirectory)?.Parent?.FullName;

            foreach (string filename in filePaths)
            {

                if (folderPath is not null)
                {
                    if (filename.Contains("Data"))
                    {
                        var thisRainfallDatas = ReadCsv<RainfallData>(Path.Combine(folderPath, filename));

                        rainfallDatas.AddRange(thisRainfallDatas);
                    }

                    if (filename.Contains("Devices"))
                    {
                        var device = ReadCsv<Devices>(Path.Combine(folderPath, filename));

                        devices.AddRange(device);
                    }
                }
            }

            if (rainfallDatas != null)
            {
                
                DateTime currentDatetime = new DateTime(2020, 05, 06, 15, 0, 0);
                Console.WriteLine($"Rainfall Measurement for Current Timestamp: {currentDatetime.ToString("dd/MM/yyyy HH:mm")} over last 4 hours on each devices.");
                foreach (var device in devices)
                {
                        
                    Console.WriteLine($"Device ID: {device.DeviceID}\nDevice Name: {device.DeviceName}\nDevice Location: {device.Location}");

                    var result = rainfallDatas.Where(x =>x.DeviceID == device.DeviceID && x.DateTime <= currentDatetime && x.DateTime >= currentDatetime.AddHours(-4)).ToList();

                    if (result is not null && result.Count > 0)
                    {
                        var average = GetAverage(result);
                        var trend = GetTrend(result);

                        Console.WriteLine("Average\tRecords\t\tRating\tTrend");
                        if (average < 10)
                        {
                            Console.WriteLine($"{average}\t{result.Count}\t\tGreen\t{trend}");
                        }
                        else if (average < 15)
                        {
                            Console.WriteLine($"{average}\t{result.Count}\t\tAmber\t{trend}");
                        }
                        else if (average >= 15 || result.Where(x => x.Measurement > 30).Any())
                        {
                            Console.WriteLine($"{average}\t{result.Count}\t\tRed\t{trend}");
                        }
                        else
                        {
                            Console.WriteLine($"{average}\t{result.Count}\tNa\t{trend}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"NA\tNA\tNa\tNA");
                    }
                    Console.WriteLine("\n");
                }

            }
            
        }

    }
}
