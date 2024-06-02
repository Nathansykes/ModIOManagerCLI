using Cocona;
using ModIOManagerCLI.Commands;
using ModIOManagerCLI.Configuration;


[HasSubCommands(typeof(ConfigCommands), Description = "Config commands")]
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = CoconaApp.CreateBuilder();

        builder.Services.ConfigureServices(builder.Configuration);

        var app = builder.Build();

        app.ConfigureApp(builder.Configuration);

        app.Run();

    }
}