using Cocona;
using ModIOManagerCLI.API;
using ModIOManagerCLI.Settings;
using System.Diagnostics;
using System.IO;

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
    [Command("edit")]
    public void OpenConfig()
    {
        Console.WriteLine("Opening config file");

        using Process p = new Process();
        p.StartInfo = new ProcessStartInfo("\"" + Config.FilePath + "\"")
        {
            UseShellExecute = true
        };
        p.Start();
        //fileopener.StartInfo.FileName = "explorer";
        //fileopener.StartInfo.Arguments = "\"" + Config.FilePath + "\"";
        //fileopener.Start();
    }
}