using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModIOManagerCLI.API;
using ModIOManagerCLI.Settings;

namespace ModIOManagerCLI.Configuration;
public static class Services
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureHttpClients();
    }
    public static void ConfigureHttpClients(this IServiceCollection services)
    {
        services.AddHttpClient();
        services.AddHttpClient(NamedHttpClients.ModIO, SetupClient);
        services.AddHttpClient<ModIOClient>(SetupClient);
    }
    private static void SetupClient(HttpClient client)
    {
        client.BaseAddress = new Uri($"https://u-{Config.Instance.UserId}.modapi.io/v1/");
        client.DefaultRequestHeaders.Authorization = new("Bearer", Config.Instance.Token);
    }
}
