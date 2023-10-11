using System.ComponentModel.Design;
using FileBaseContext.Context.Models.Configurations;
using Microsoft.Extensions.DependencyInjection;
using N52_HT1_Console.Events;
using N52_HT1_Console.Models;
using N52_HT1_Console.Services;
using N52_HT1_Console.Services.Interfaces;
using N52_HT1.DataAccess;

var builder = new ServiceCollection();

builder.AddSingleton<IDataContext, AppFileContext>(_ =>
{
    var options = new FileContextOptions<AppFileContext>
    {
        StorageRootPath = @"/home/abdura/PROJECTS/Level_1_Part_2/N52-HT1-Console/DataStorage"
    };

    var context = new AppFileContext(options);
    context.FetchAsync().AsTask().Wait();
    return context;
});

builder.AddSingleton<IUserService, UserService>()
    .AddSingleton<IAccountService, AccountService>()
    .AddSingleton<IEmailSenderService, EmailSenderService>()
    .AddSingleton<AccountEventStore>();

var provider = builder.BuildServiceProvider();

var userService = provider.GetService<IUserService>();
var accountService = provider.GetRequiredService<IAccountService>();

var user = new User("Azizbek", "Abdruahmonov", "abdura52.uz@gmail.com");
await userService.CreateAsync(user);