using RainfallDetector.Services;

class Program
{
    static void Main(string[] args)
    {
        //File source
        List<string> filePaths = new List<string>() { 
            "Assets/Data1.csv" ,
            "Assets/Data2.csv" ,
            "Assets/Devices.csv"
        };


        //Initialization
        IRainfallCalculator rainfallCalculator = new RainfallCalculator();

        //Execution
        rainfallCalculator.Get(filePaths);
    }
}