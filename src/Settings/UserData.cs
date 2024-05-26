using System.Text.Json;

namespace ModIOManagerCLI.Settings;
public class UserData
{
    private static UserData? _instance;
    public static UserData Instance { get => _instance ??= Read(); private set => _instance = value; }
    public static string FilePath => Path.Combine(Environment.CurrentDirectory, "config.json");
    public static UserData Read() => ConfigUtils.Read<UserData>(FilePath);
    public static void Save() => ConfigUtils.Save(Instance, FilePath);

    public List<Game> Mods { get; set; } = [];
}

public class Game
{
    public string GameId { get; set; } = "";
    public string GameIOName { get; set; } = "";
    public string GameInstallPath { get; set; } = "";
    public string GameModsFolder { get; set; } = "";
    public List<Mod> Mods { get; set; } = [];
}

public class Mod
{
    public string ModId { get; set; } = "";
    public string ModIOName { get; set; } = "";
    public string LocalName { get; set; } = "";
    public string LocalPath { get; set; } = "";
}