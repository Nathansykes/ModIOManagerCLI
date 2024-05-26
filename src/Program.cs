using Cocona;
using ModIOManagerCLI.Configuration;

var builder = CoconaApp.CreateBuilder();

builder.Services.ConfigureServices(builder.Configuration);

var app = builder.Build();

app.ConfigureApp(builder.Configuration);

app.Run();
