using FileBaseContext.Context.Models.Configurations;
using N53_HT1.Api.DataAccess;
using N53_HT1.Api.Events;
using N53_HT1.Api.Interfaces;
using N53_HT1.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton<IDataContext, AppFileContext>(_ =>
{
    var options = new FileContextOptions<AppFileContext>
    {
        StorageRootPath = Path.Combine(builder.Environment.ContentRootPath, "Data", "DataStorage")
    };

    var context = new AppFileContext(options);
    context.FetchAsync().AsTask().Wait();
    return context;
});


builder.Services.AddSingleton<IUserService, UserService>()
    .AddSingleton<OrderEventStore>()
    .AddSingleton<BonusEventStore>()
    .AddSingleton<UserBonusService>()
    .AddSingleton<UserPromotionService>()
    .AddSingleton<IBonusService, BonusService>()
    .AddSingleton<IOrderService, OrderService>()
    .AddSingleton<INotificationService, EmailSenderService>()
    .AddSingleton<INotificationService, SmsSenderService>()
    .AddSingleton<INotificationService, TelegramSenderService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var test = app.Services.GetRequiredService<UserPromotionService>();
var testB = app.Services.GetRequiredService<UserBonusService>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
