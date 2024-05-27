namespace ModIOManagerCLI.Services;

public class AuthService(IHttpClientFactory httpClientFactory)
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;

    public async Task<bool> TestConnection()
    {
        var client = _httpClientFactory.CreateClient(NamedHttpClients.ModIO);
        var response = await client.GetAsync("me");
        return response.IsSuccessStatusCode;
    }
}
