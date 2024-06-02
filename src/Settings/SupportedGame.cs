using ModIOManagerCLI.Utils;
using System.Diagnostics.CodeAnalysis;

namespace ModIOManagerCLI.Settings;

public abstract class SupportedGame : IEquatable<SupportedGame>
{
    public static readonly BMXStreets BMXStreets = new();

    public static readonly List<SupportedGame> GamesList =
    [
        BMXStreets
    ];

    public static SupportedGame? Find(string search, bool writeIfError = true)
    {
        var supportedGame = GamesList.FuzzyFind(g => g.Name, search);
        if (writeIfError && supportedGame is null)
        {
            Console.WriteLine($"Game not found or not supported '{search}'");
            WriteListToConsole();
            return null;
        }
        return supportedGame;
    }
    public static void WriteListToConsole()
    {
        Console.WriteLine("Supported games:");
        foreach (var game in GamesList)
        {
            Console.WriteLine($" - {game.Name}");
        }
    }


    public abstract Game GetGame();
    public abstract void ParseMods(Game game);

    public required string Name { get; init; }
    public required string NameId { get; init; }
    public required int Id { get; init; }

    
    public override bool Equals(object? obj)
    {
        if (obj is not SupportedGame game)
            return false;
        return Equals(game);
    }
    public bool Equals(SupportedGame? other) => Id == other?.Id;
    public static bool operator ==(SupportedGame? left, SupportedGame? right) => left?.Equals(right) ?? right is null;
    public static bool operator !=(SupportedGame? left, SupportedGame? right) => !(left == right);
    public override int GetHashCode() => Id.GetHashCode();
}

public class BMXStreets : SupportedGame
{
    [SetsRequiredMembers]
    public BMXStreets() : base()
    {
        Name = "BMX Streets";
        NameId = "bmxs";
        Id = 2835;
    }

    public override Game GetGame()
    {
        var game = new Game
        {
            GameId = Id,
            GameIOName = Name,
            GameModsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "BMX Streets", "Maps"),
        };
        ParseMods(game);
        return game;
    }

    public override void ParseMods(Game game)
    {
        var folders = Directory.GetDirectories(game.GameModsFolder);
        var mods = new List<Mod>();
        foreach (var folder in folders)
        {
            var files = Directory.GetFiles(folder);

            var modFileName = files.FirstOrDefault(x =>
            {
                var ext = Path.GetExtension(x);
                return string.IsNullOrWhiteSpace(ext) || ext == ".bundle";
            });
            var modName = Path.GetFileNameWithoutExtension(modFileName);
            if(string.IsNullOrWhiteSpace(modName))
                continue;

            var mod = new Mod
            {
                LocalName = modName ?? "",
                LocalPath = folder,
            };
            mods.Add(mod);
        }
        game.Mods = mods.OrderBy(x => x.LocalName).ToList();
    }
}