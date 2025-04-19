using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainfallDetector.Models
{
    public class RainfallData
    {
        [Index(0)]
        public int DeviceID { get; set; }

        [Index(1)]
        public DateTime DateTime { get; set; }

        [Index(2)]
        public int Measurement { get; set; }
    }
}
