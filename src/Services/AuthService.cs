using ModIOManagerCLI.Settings;

namespace ModIOManagerCLI.Services;
public class AuthService(IHttpClientFactory httpClientFactory)
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;

    private HttpClient CreateClient()
    {
        var client = _httpClientFactory.CreateClient();
        client.BaseAddress = new Uri($"https://u-{Config.Instance.UserId}.modapi.io/v1/");
        client.DefaultRequestHeaders.Authorization = new("Bearer", Config.Instance.Token);
        return client;
    }

    public async Task<bool> TestConnection()
    {
        var client = CreateClient();
        var response = await client.GetAsync("me");
        return response.IsSuccessStatusCode;
    }
}
