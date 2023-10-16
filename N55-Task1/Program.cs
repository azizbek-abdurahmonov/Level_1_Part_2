using N55_Task1.Services;

var folderPath = @"D:\PROJECTS";
var targetFileName = "N39-HT1.dll";


var service = new FileService();

service.FindFile(folderPath, targetFileName);