using System.Text.Json;

namespace ModIOManagerCLI.Settings;
public static class ConfigUtils
{
    public static T Read<T>(string filePath) where T : new()
    {
        if (File.Exists(filePath))
        {
            try
            {
                var content = File.ReadAllText(filePath);
                var model = JsonSerializer.Deserialize<T>(File.ReadAllText(filePath));
                if (model is null)
                {
                    model = new T();
                    Save(model, filePath);
                }
                return model;
            }
            catch
            {
                Console.WriteLine("Could not read config file");
                throw new Cocona.CommandExitedException(1);
            }
        }
        else
        {
            var model = new T();
            Save(model, filePath);
            return model;
        }
    }

    public static void Save<T>(T model, string filePath)
    {
        var content = JsonSerializer.Serialize(model, _jsonWriteOptions);
        File.WriteAllText(filePath, content);
    }

    private static readonly JsonSerializerOptions _jsonWriteOptions = new() { WriteIndented = true };
}
