using Cocona;
using Microsoft.Extensions.Configuration;
using ModIOManagerCLI.Commands;

namespace ModIOManagerCLI.Configuration;
public static class Application
{
    public static void ConfigureApp(this CoconaApp app, IConfiguration configuration)
    {
        app.AddCommandGroup<ConfigCommands>("config", "Config Commands");
        app.AddCommandGroup<ModCommands>("mods", "Mod commands");
    }

    public static void AddCommandGroup<T>(this CoconaApp app, string groupName, string description) where T : class
    {
        app.AddSubCommand(groupName, c =>
        {
            c.AddCommands<T>();
        }).WithDescription(description);
    }
}
