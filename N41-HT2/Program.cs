using N41_HT2.Models;
using N41_HT2.Services;

var user1 = new User("Gishtmat", "Toshmatov", "abdura52.uz@gmail.com");
var user2 = new User("John", "Doe", "abdura52.uz@gmail.com");

var template1 = new EmailTemplate(user1, Constants.WelcomeSubject, Constants.WelcomeBody);
var template2 = new EmailTemplate(user2, Constants.WelcomeSubject, Constants.WelcomeBody);

var emailSenderService = new EmailSenderService();

var tasks = new List<Task>
{
    new(() => emailSenderService.SendEmailAsync(template1)),
    new(() => emailSenderService.SendEmailAsync(template2))
};

Parallel.ForEach(tasks, task => task.Start());
await Task.WhenAll(tasks);