using CardsApp.Client.ApiConnection.DTOs;

namespace CardsApp.Client.ApiConnection.Interfaces;

public interface IApiCardService
{
    public Task CreateCard(CardDto card);
    
    public Task<IEnumerable<CardDto>> GetAllCards();

    public Task<CardDto> GetCardById(Guid id);

    public Task UpdateCard(Guid id, CardDto card);

    public Task DeleteCard(Guid id);
}