namespace ModIOManagerCLI.Settings;
public class UserData
{
    private static UserData? _instance;
    public static UserData Instance { get => _instance ??= Read(); private set => _instance = value; }
    public static string FilePath => Path.Combine(Environment.CurrentDirectory, "userdata.json");
    public static UserData Read()
    {
        var data = ConfigUtils.Read<UserData>(FilePath);
        if (data.Games.Count == 0)
            Init(data);
        return data;
    }

    public static void Save() => ConfigUtils.Save(Instance, FilePath);

    private static void Init(UserData data)
    {
        foreach (var item in SupportedGame.GamesList)
        {
            var game = item.GetGame();
            var current = data.Games.FirstOrDefault(x => x.GameId == game.GameId);
            if (current is null)
            {
                data.Games.Add(game);
                current = game;
            }
            current.Mods = game.Mods;
        }
        _instance = data;
        Save();
    }

    public List<Game> Games { get; set; } = [];
}

public class Game
{
    public int GameId { get; set; }
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