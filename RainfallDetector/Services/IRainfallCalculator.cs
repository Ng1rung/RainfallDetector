using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainfallDetector.Services
{
    public interface IRainfallCalculator
    {
        void Get(List<string> filePaths);
    }
}
