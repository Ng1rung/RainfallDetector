using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainfallDetector.Models
{
    public class Devices
    {
        [Index(0)]
        public int DeviceID { get; set; }

        [Index(1)]
        public string? DeviceName { get; set; }

        [Index(2)]
        public string? Location { get; set; }
    }
}
