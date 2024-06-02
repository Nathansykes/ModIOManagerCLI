using ModIOManagerCLI.API;
using ModIOManagerCLI.Utils;
using System.Net.Http;
using System.Text.Json;

namespace ModIOManagerCLI.Services;
public class ModIOClient(HttpClient client)
{
    private readonly HttpClient _client = client;

    public async Task<bool> TestConnection()
    {
        var response = await _client.GetAsync("me");
        return response.IsSuccessStatusCode;
    }

    public async Task<List<ModObject>> GetSubscribedMods(int? gameId)
    {
        var path = new UrlQueryParameterDictionary("me/subscribed");
        if (gameId.HasValue)
            path.Add("game_id", gameId);

        var mods = new List<ModObject>();

        int offset = 0;
        int limit = 100;
        int total;
        do
        {
            path["_offset"] = offset;
            path["_limit"] = limit;

            var response = await _client.GetAsync(path.ToString());
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var responseObj = JsonSerializer.Deserialize<APIListResponse<ModObject>>(content)!;
            mods.AddRange(responseObj.Data);

            offset += limit;
            total = responseObj.ResultTotal;
        } while (total != 0 && offset < total);

        return mods;
    }
}
