using Cocona;
using ModIOManagerCLI.Services;

namespace ModIOManagerCLI.Commands;
public class ModCommands(ModService modService) : CommandBase
{
    private readonly ModService _modService = modService;

    [Command("mods")]
    public async Task Mods()
    {
        var mods = await _modService.GetSubscribedMods(null);
        foreach (var mod in mods)
        {
            Console.WriteLine(mod.Name);
        }
    }
}
