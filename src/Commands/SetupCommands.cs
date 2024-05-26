using Cocona;
using ModIOManagerCLI.Services;
using ModIOManagerCLI.Settings;

namespace ModIOManagerCLI.Commands;

public class SetupCommands(AuthService authService) : CommandBase
{
    private readonly AuthService _authService = authService;

    [Command("init")]
    public void Init()
    {
        _ = Config.Instance;
        _ = UserData.Instance;
        Console.WriteLine("Initialized");
        Console.WriteLine("Config files created successfully");
    }

    [Command("test-connection")]
    public async Task<bool> TestConnection()
    {
        return await _authService.TestConnection();
    }
}
