using System.Threading.Tasks;
using CardsApp.Client.Wpf.Stores;
using CardsApp.Client.Wpf.ViewModels;

namespace CardsApp.Client.Wpf.Commands;

public class DeleteCardCommand : AsyncCommandBase
{
    private readonly CardsListItemViewModel cardsListItemViewModel;
    private readonly CardsStore cardsStore;


    public DeleteCardCommand(CardsListItemViewModel cardsListItemViewModel, CardsStore cardsStore)
    {
        this.cardsListItemViewModel = cardsListItemViewModel;
        this.cardsStore = cardsStore;
    }

    public override async Task ExecuteAsync(object? parameter)
    {
        try
        {
            var cardToDelete = this.cardsListItemViewModel.CardModel;
            await this.cardsStore.Delete(cardToDelete.Id);
        }
        catch
        {
            throw;
        }
        
    }
}