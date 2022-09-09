using CardApp.Server.Dal.Exceptions;
using CardApp.Server.Dal.Interfaces;
using CardApp.Server.Dal.Models;
using JsonFlatFileDataStore;

namespace CardApp.Server.Dal.Services;

public class DefaultCardInfoRepository : ICardInfoRepository
{
    private readonly IDocumentCollection<CardRepositoryModel> cardsCollection;

    public DefaultCardInfoRepository(string filePath)
    {
        var dataStore = new DataStore(filePath, keyProperty: "Id");
        this.cardsCollection = dataStore.GetCollection<CardRepositoryModel>();
    }
    
    public Task<IEnumerable<CardRepositoryModel>> GetAllCardsAsync()
    {
        return Task.Run(() => this.cardsCollection.AsQueryable());
    }

    public Task<CardRepositoryModel> GetCardByIdAsync(Guid id)
    {
        return Task.Run(() =>this.cardsCollection.Find(x => x.Id == id).FirstOrDefault()  
                             ?? throw new CardNotFoundException($"There are no card with Id {id}"));
    }

    public async Task<Guid> CreateCardAsync(CardRepositoryModel card)
    {
        var isInserted  = await this.cardsCollection.InsertOneAsync(card);
        if (isInserted)
        {
            return card.Id;
        }

        if (!IfCardExists(card.Id))
        {
            throw new CardNotFoundException($"Card with id {card.Id} was not found");
        }

        throw new TransactionException("Can not insert card");

    }

    public async Task UpdateCardAsync(Guid cardId, CardRepositoryModel newCard)
    {
        var isUpdated  = await cardsCollection.ReplaceOneAsync(x => x.Id == cardId, newCard);
        if (!isUpdated)
        {
            if (!IfCardExists(newCard.Id))
            {
                throw new CardNotFoundException($"Card with id {newCard.Id} was not found");
            }
            
            throw new TransactionException("Can not update card.");
        }
    }

    public async Task DeleteCardAsync(Guid id)
    {
        var isDeleted  = await cardsCollection.DeleteOneAsync(x => x.Id == id);
        if (!isDeleted)
        {
            if (!IfCardExists(id))
            {
                throw new CardNotFoundException($"Card with id {id} was not found");
            }
            
            throw new TransactionException("Can not update card.");
        }
    }

    private bool IfCardExists(Guid id)
    {
        return cardsCollection.Find(x => x.Id == id).FirstOrDefault() != null;
    }
}