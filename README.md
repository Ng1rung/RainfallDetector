# RainfallDetector

This console app is used to find the status and trend of the rainfall for last 4 hours. It extracts the data from the folder with csv format files and process it as required.
The threshold are:
Green:  average rainfall for last 4 hrs < 10mm
Amber:  average rainfall for last 4 hrs < 15mm
Red:  average rainfall for last 4 hrs >= 15mm or any reading in the last 4 hrs > 30mm

Thrend: If latest recording is higher than previous recording, its increasing. Else the trend is decresing.


# Requirement used
CSVHelper packages
Dotnet v8


# Usage
Upload the csv file in the assets folder.
File with name containing 'data' is processed as data of rainfal.
File with name devices 'device' is processed as devices meta data.



```bash
dotnet build
dotnet run
