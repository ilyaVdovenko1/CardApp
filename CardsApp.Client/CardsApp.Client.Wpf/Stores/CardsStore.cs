using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CardsApp.Client.Domain.Interfaces;
using CardsApp.Client.Domain.Models;

namespace CardsApp.Client.Wpf.Stores;

public class CardsStore
{
    private readonly ICardsAppService cardsAppService;

    private readonly List<Card> cards;
    public IEnumerable<Card> Cards => cards;
    
    public event Action<Card>? CardAdded;
    
    public event Action<Card>? CardUpdated;

    public event Action? CardsLoaded;
    
    public event Action<Guid>? CardsDeleted;
    

    public CardsStore(ICardsAppService cardsAppService)
    {
        this.cardsAppService = cardsAppService;
        this.cards = new List<Card>();
    }
    
    public async Task Load()
    {
        var cards = await this.cardsAppService.GetAllCards();
        this.cards.Clear();
        this.cards.AddRange(cards);
        
        CardsLoaded?.Invoke();
        
    }
    
    public async Task Delete(Guid id)
    {
        await cardsAppService.DeleteCard(id);

        cards.RemoveAll(x => x.Id == id);
        
        CardsDeleted?.Invoke(id);
        
    }

    public async Task Add(Card card)
    {
        await this.cardsAppService.CreateCard(card);
        
        this.cards.Add(card);
        
        CardAdded?.Invoke(card);
    }
    
    public async Task Update(Card card)
    {
        await this.cardsAppService.UpdateCard(card.Id, card);

        var id = this.cards.FindIndex(x => x.Id == card.Id);
        
        if (id > 1)
        {
            this.cards[id] = card;
        }
        
        CardUpdated?.Invoke(card);
    }
}