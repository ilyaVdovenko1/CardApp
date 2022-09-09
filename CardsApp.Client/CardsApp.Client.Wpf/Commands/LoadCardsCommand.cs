using System;
using System.Threading.Tasks;
using CardsApp.Client.Wpf.Stores;

namespace CardsApp.Client.Wpf.Commands;

public class LoadCardsCommand: AsyncCommandBase
{
    private readonly CardsStore cardsStore;

    public LoadCardsCommand(CardsStore cardsStore)
    {
        this.cardsStore = cardsStore;
    }

    public override async Task ExecuteAsync(object? parameter)
    {
        try
        {
            await this.cardsStore.Load();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
}