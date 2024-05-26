using Cocona;
using Microsoft.Extensions.Configuration;
using ModIOManagerCLI.Commands;
using System.Reflection;

namespace ModIOManagerCLI.Configuration;
public static class Application
{
    public static void ConfigureApp(this CoconaApp app, IConfiguration configuration)
    {
        app.AddCommands<SetupCommands>();
    }
}
