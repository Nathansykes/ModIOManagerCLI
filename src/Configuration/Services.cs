using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModIOManagerCLI.Services;

namespace ModIOManagerCLI.Configuration;
public static class Services
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient();
        services.AddSingleton<AuthService>();
    }

}
