using Cocona;
using ModIOManagerCLI.Commands;
using ModIOManagerCLI.Configuration;
using System.Diagnostics;


[HasSubCommands(typeof(ConfigCommands), Description = "Config commands")]
internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            var builder = CoconaApp.CreateBuilder();

            builder.Services.ConfigureServices(builder.Configuration);

            var app = builder.Build();

            app.ConfigureApp(builder.Configuration);

            app.Run();
        }
        catch
        {
            Console.WriteLine("A fatal error occurred");
            Process.GetCurrentProcess().Kill(true);
        }

    }
}