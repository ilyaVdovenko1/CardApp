using CardApp.Server.Bll.Models;

namespace CardApp.Server.Bll.Interfaces;

public interface ICardInfoService
{
    public Task<IEnumerable<Card>> GetAllCardsAsync();

    public Task<Card> GetCardByIdAsync(Guid id);

    public Task<Guid> CreateCardAsync(Card card);

    public Task UpdateCardAsync(Guid cardId, Card newCard);

    public Task DeleteCardAsync(Guid id);
}