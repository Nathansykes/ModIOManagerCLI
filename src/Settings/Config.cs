namespace ModIOManagerCLI.Settings;
public class Config
{
    private static Config? _instance;
    public static Config Instance { get => _instance ??= Read(); private set => _instance = value; }
    public static string FilePath => Path.Combine(Environment.CurrentDirectory, "config.json");
    public static Config Read() => ConfigUtils.Read<Config>(FilePath);
    public static void Save() => ConfigUtils.Save(Instance, FilePath);

    public string ApiKey { get; set; } = "";
    public string ClientId { get; set; } = "";
    public string Token { get; set; } = "";
    public string UserId { get; set; } = "";
}
