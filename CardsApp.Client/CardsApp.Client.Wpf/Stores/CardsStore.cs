using System;
using System.Threading.Tasks;
using CardsApp.Client.Wpf.Models;

namespace CardsApp.Client.Wpf.Stores;

public class CardsStore
{
    public event Action<Card>? CardAdded;
    
    public event Action<Card>? CardUpdated;

    public async Task Add(Card card)
    {
        CardAdded?.Invoke(card);
    }
    
    public async Task Update(Card card)
    {
        CardUpdated?.Invoke(card);
    }
}