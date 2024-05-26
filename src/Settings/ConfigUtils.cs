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
                throw;
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
        if (!File.Exists(filePath))
            File.Create(filePath).Close();
        using var sw = new StreamWriter(filePath, true);
        var content = JsonSerializer.Serialize(model, _jsonWriteOptions);
        sw.Write(content);
    }

    private static readonly JsonSerializerOptions _jsonWriteOptions = new() { WriteIndented = true };
}
