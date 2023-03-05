using webapi.BackgroundServices;
using webapi.Contracts.Services;
using webapi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<IPubService, PubService>();
builder.Services.AddTransient<ISubService, SubService>();
builder.Services.AddHostedService<SubscriberBackgroundService>();

var app = builder.Build();

app.Run();
