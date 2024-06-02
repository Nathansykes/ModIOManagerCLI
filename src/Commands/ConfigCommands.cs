using Cocona;
using ModIOManagerCLI.Services;
using ModIOManagerCLI.Settings;

namespace ModIOManagerCLI.Commands;

public class ConfigCommands(ModIOClient client) : CommandBase
{
    private readonly ModIOClient _client = client;

    [Command("test")]
    public async Task Test()
    {
        _ = Config.Instance;
        _ = UserData.Instance;
        Console.WriteLine("Initialized");
        Console.WriteLine("Config files validated");
        var connected = await _client.TestConnection();
        Console.WriteLine($"Mod.io connection test: {(connected ? "Success" : "Failed")}");
    }
    [Command("testagain")]
    public async Task TestAgain()
    {
        _ = Config.Instance;
        _ = UserData.Instance;
        Console.WriteLine("Initialized");
        Console.WriteLine("Config files validated");
        var connected = await _client.TestConnection();
        Console.WriteLine($"Mod.io connection test: {(connected ? "Success" : "Failed")}");
    }
}