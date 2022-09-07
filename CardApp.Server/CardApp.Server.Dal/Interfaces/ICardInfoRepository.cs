using CardApp.Server.Dal.Models;

namespace CardApp.Server.Dal.Interfaces;

public interface ICardInfoRepository
{
    public Task<IEnumerable<CardRepositoryModel>> GetAllCardsAsync();

    public Task<CardRepositoryModel> GetCardByIdAsync(Guid id);

    public Task<Guid> CreateCardAsync(CardRepositoryModel card);

    public Task UpdateCardAsync(Guid cardId, CardRepositoryModel newCard);

    public Task DeleteCardAsync(Guid id);
}