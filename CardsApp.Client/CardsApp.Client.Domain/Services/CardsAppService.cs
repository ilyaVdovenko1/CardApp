
using CardsApp.Client.ApiConnection.Interfaces;
using CardsApp.Client.Domain.Extensions;
using CardsApp.Client.Domain.Interfaces;
using CardsApp.Client.Domain.Models;

namespace CardsApp.Client.Domain.Services;

public class CardsAppService : ICardsAppService
{
    private readonly IApiCardService apiCardService;

    public CardsAppService(IApiCardService apiCardService)
    {
        this.apiCardService = apiCardService;
    }
    public async Task CreateCard(Card card)
    {
        try
        {
            await apiCardService.CreateCard(card.MapToCardDtoFromCard());
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine(e);
            throw new InvalidOperationException("Could not perform operation right now.");
        }
        
    }

    public async Task<IEnumerable<Card>> GetAllCards()
    {
        try
        {
            var cards = await apiCardService.GetAllCards();
            
            return cards.Select(x => x.MapToCardFromCardDto());
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine(e);
            throw new InvalidOperationException("Could not perform operation right now.");
        }
    }

    public async Task<Card> GetCardById(Guid id)
    {
        try
        {
            var card = await apiCardService.GetCardById(id);

            return card.MapToCardFromCardDto();
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine(e);
            throw new InvalidOperationException("Could not perform operation right now.");
        }
    }

    public async Task UpdateCard(Guid id, Card card)
    {
        try
        {
             await apiCardService.UpdateCard(id, card.MapToCardDtoFromCard());
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine(e);
            throw new InvalidOperationException("Could not perform operation right now.");
        }
    }

    public async Task DeleteCard(Guid id)
    {
        try
        {
            await apiCardService.DeleteCard(id);
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine(e);
            throw new InvalidOperationException("Could not perform operation right now.");
        }
    }
}