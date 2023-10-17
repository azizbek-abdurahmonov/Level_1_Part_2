using N56_HT1.Extensions;
using N56_HT1.Models;
using N56_HT1.Services;

var userA = new User(Guid.Parse("8a660e18-9f70-47ee-a095-aa7c66c6e547"), "John");

var userB = new User(Guid.Parse("12276639-5da5-4d10-a318-ed64822287e1"),"Gishtmat");

var userC = new User(Guid.Parse("ef068425-4543-4800-897c-1b201275a292"), "Toshmat");


//userB.InitializeUserFolders();

//userA.InitializeUserFolders();

//userC.InitializeUserFolders();

// Yuqoridagi kod tekshirish uchun edi. User uchun folderlarni yaratib olish uchun! 

var directoryService = new DirectoryService();
var fileService = new FileService();
var cleanerService = new CleanUpService(directoryService, fileService);


var invalidDocuments = await cleanerService.CleanAsync(userA);
invalidDocuments.ForEach(Console.WriteLine);