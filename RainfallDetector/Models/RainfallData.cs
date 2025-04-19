using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainfallDetector.Models
{
    public class RainfallData
    {
        public int DeviceID { get; set; }
        public DateTime DateTime { get; set; }
        public float Measurement { get; set; }
    }
}
