using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModIOManagerCLI.Services;
using ModIOManagerCLI.Settings;

namespace ModIOManagerCLI.Configuration;
public static class Services
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<AuthService>();
        services.AddSingleton<ModService>();
        services.ConfigureHttpClients();
    }
    public static void ConfigureHttpClients(this IServiceCollection services)
    {
        services.AddHttpClient();
        services.AddHttpClient(NamedHttpClients.ModIO, client =>
        {
            client.BaseAddress = new Uri($"https://u-{Config.Instance.UserId}.modapi.io/v1/");
            client.DefaultRequestHeaders.Authorization = new("Bearer", Config.Instance.Token);
        });
    }
}
