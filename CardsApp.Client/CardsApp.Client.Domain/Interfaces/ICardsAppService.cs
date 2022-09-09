using CardsApp.Client.Domain.Models;

namespace CardsApp.Client.Domain.Interfaces;

public interface ICardsAppService
{
    public Task CreateCard(Card card);
    
    public Task<IEnumerable<Card>> GetAllCards();

    public Task<Card> GetCardById(Guid id);

    public Task UpdateCard(Guid id, Card card);

    public Task DeleteCard(Guid id);
}