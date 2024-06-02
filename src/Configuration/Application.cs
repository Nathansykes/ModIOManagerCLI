using Cocona;
using Microsoft.Extensions.Configuration;
using ModIOManagerCLI.Commands;
using System.Diagnostics;

namespace ModIOManagerCLI.Configuration;
public static class Application
{
    public static void ConfigureApp(this CoconaApp app, IConfiguration configuration)
    {
        app.UseFilter(async (context, next) =>
        {
            try
            {
                return await next(context);
            }
            catch (CommandExitedException)
            {
                throw;
            }
            catch
            {
                Console.WriteLine("A fatal error occurred");
                throw new CommandExitedException(1);
            }
        });
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
