//using N37_HT1.Models;
//using N37_HT1.Enums;
//using System.Text.Json;

//var users = new List<User>
//{
//    new User("Azizbek", "Abdurahmonov", "abdura52.uz@gmail.com", Status.Active),
//    new User("Abdura", "Abdura", "Abdura@gm.com", Status.Registered)
//};

//var templates = new List<EmailTemplate>
//{
//    new EmailTemplate("First subject", "First subject's body"),
//    //new EmailTemplate("Second subject", "Second subject's body"),
//};

//var result = users.Zip(templates);
//Console.WriteLine(result.Last().First.FirstName);

using N37_HT1.Services;
using N37_HT1.Models;
using N37_HT1.Enums;

var userService = new UserService();
var emailService = new EmailService();
var emailTemplateService = new EmailTemplateService();
var emailSenderService = new EmailSenderService();

var notificationService = new NotificationManagementService(userService, emailService, emailTemplateService, emailSenderService);

userService.users.Add(new User("Abdura", "Abdura", "abdura52.uz@gmail.com", Status.Deleted));
userService.users.Add(new User("Habiba", "Sattorova", "sattorovahabiba00@gmail.com", Status.Registered));
await notificationService.NotifyUsers();
