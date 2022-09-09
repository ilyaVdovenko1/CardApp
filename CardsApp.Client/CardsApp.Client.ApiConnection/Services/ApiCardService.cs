using System.Net;
using System.Net.Http.Json;
using CardsApp.Client.ApiConnection.DTOs;
using CardsApp.Client.ApiConnection.Interfaces;

namespace CardsApp.Client.ApiConnection.Services;

public class ApiCardService : IApiCardService
{
    private const string ControllerName = "Cards/api";
    private readonly HttpClient httpClient;

    public ApiCardService(string baseUrl)
    {
        this.httpClient = new HttpClient()
        {
            BaseAddress = new Uri(baseUrl),

        };
    }

    public async Task CreateCard(CardDto card)
    {
        HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, ControllerName);
        requestMessage.Content = JsonContent.Create(card);
        
        var response = await httpClient.SendAsync(requestMessage);

        response.EnsureSuccessStatusCode();
    }

    public async Task<IEnumerable<CardDto>> GetAllCards()
    {
        var responce = await httpClient.GetAsync(ControllerName);
        var cards = await responce.Content.ReadAsAsync<IEnumerable<CardDto>>()
                    ?? throw new HttpRequestException("Can not recognize the server answer.");
        return cards;
    }

    public async Task<CardDto> GetCardById(Guid id)
    {
        var responce = await httpClient.GetAsync($"{ControllerName}?id={id}");
        if (responce.StatusCode == HttpStatusCode.NotFound)
        {
            throw new ArgumentException($"No card with this id {id}");
        }
        
        responce.EnsureSuccessStatusCode();
        var card = await responce.Content.ReadAsAsync<CardDto>();
        return card;
    }

    public async Task UpdateCard(Guid id, CardDto card)
    {
        HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Put, $"{ControllerName}?oldCardId={id}");
        requestMessage.Content = JsonContent.Create(card);
        
        
        var responce = await httpClient.SendAsync(requestMessage);
        if (responce.StatusCode == HttpStatusCode.NotFound)
        {
            throw new ArgumentException($"No card with this id {id}");
        }
        
        responce.EnsureSuccessStatusCode();
        
    }

    public async Task DeleteCard(Guid id)
    {
        
        var responce = await httpClient.DeleteAsync($"{ControllerName}?cardId={id}");
        if (responce.StatusCode == HttpStatusCode.NotFound)
        {
            throw new ArgumentException($"No card with this id {id}");
        }
        
        responce.EnsureSuccessStatusCode();
    }
}