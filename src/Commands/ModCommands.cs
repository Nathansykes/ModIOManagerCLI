using Cocona;
using ModIOManagerCLI.Services;
using ModIOManagerCLI.Settings;

namespace ModIOManagerCLI.Commands;
public class ModCommands(ModIOClient client) : CommandBase
{
    private readonly ModIOClient _client = client;

    [Command("list", Description = "Get subscribed mods")]
    public async Task ListMods([Option("game", ['g'], Description = "Filter by a specific game")]string? game = null)
    {
        SupportedGame? supportedGame = null;
        if (!string.IsNullOrWhiteSpace(game))
        {
            supportedGame = SupportedGame.Find(game);
            if (supportedGame is null)
                return;
            Console.WriteLine($"Getting mods for game {supportedGame.Name}");
        }

        var mods = await _client.GetSubscribedMods(supportedGame?.Id);
        foreach (var mod in mods)
        {
            Console.WriteLine(mod.Name);
        }
    }

    //[Command("install", Description = "Installs all subscribed mods")]
    //public async Task ListMods([Option("game", ['g'], Description = "Filter by a specific game")] string? game = null)
    //{

    //}
}
