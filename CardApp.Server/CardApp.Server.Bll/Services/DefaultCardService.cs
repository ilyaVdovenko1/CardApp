using CardApp.Server.Bll.Extensions;
using CardApp.Server.Bll.Interfaces;
using CardApp.Server.Bll.Models;
using CardApp.Server.Dal.Exceptions;
using CardApp.Server.Dal.Interfaces;

namespace CardApp.Server.Bll.Domain;

public class DefaultCardService : ICardInfoService
{
    private readonly ICardInfoRepository cardInfoRepository;

    public DefaultCardService(ICardInfoRepository cardInfoRepository)
    {
        this.cardInfoRepository = cardInfoRepository;
    }
    public async Task<IEnumerable<Card>> GetAllCardsAsync()
    {
        var cardsRepos = await cardInfoRepository.GetAllCardsAsync();

        return cardsRepos.Select(x => x.MapToCard());

    }

    public async Task<Card> GetCardByIdAsync(Guid id)
    {
        try
        {
            var card = await cardInfoRepository.GetCardByIdAsync(id);

            return card.MapToCard();
        }
        catch (CardNotFoundException)
        {
            throw new ArgumentException($"No card with this id {id}", nameof(id));
        }
    }

    public async Task<Guid> CreateCardAsync(Card card)
    {
        try
        {
            await cardInfoRepository.CreateCardAsync(card.MapFromCard());
        
            return card.Id;
        }
        catch (CardNotFoundException)
        {
            throw new ArgumentException($"No card with this id {card.Id}");
        }
        catch (TransactionException)
        {
            throw new InvalidOperationException("Can not perform creating of card.");
        }
    }

    public async Task UpdateCardAsync(Guid cardId, Card newCard)
    {
        
        
        try
        {
            await cardInfoRepository.UpdateCardAsync(cardId, newCard.MapFromCard());
        }
        catch (CardNotFoundException)
        {
            throw new ArgumentException($"No card with this id {cardId}");
        }
        catch (TransactionException)
        {
            throw new InvalidOperationException("Can not perform updating of card.");
        }
    }

    public async Task DeleteCardAsync(Guid id)
    {
        try
        {
            await cardInfoRepository.DeleteCardAsync(id);
        }
        catch (CardNotFoundException)
        {
            throw new ArgumentException($"No card with this id {id}");
        }
        catch (TransactionException)
        {
            throw new InvalidOperationException("Can not perform deleting of card.");
        }
    }
}