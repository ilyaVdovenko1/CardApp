using System.Net;
using System.Text.Json;

namespace CardsApp.Client.ApiConnection.Services;

public class CardsApiHttpClient
{
    private readonly HttpClient client;

    public CardsApiHttpClient(HttpClient client)
    {
        this.client = new HttpClient();
    }

    public async Task<T> GetAsync<T>(string url)
    {
        var responseMessage = await client.GetAsync(url);
        return responseMessage.StatusCode switch
        {
            HttpStatusCode.Accepted =>
                JsonSerializer.Deserialize<T>(await responseMessage.Content.ReadAsStringAsync()) ??
                throw new InvalidOperationException("Can not deserialize server responce"),
            HttpStatusCode.NotFound => throw new ArgumentException("No content for this request where found."),
            _ => throw new ArgumentException("Server error.")
        };
    }
    
}