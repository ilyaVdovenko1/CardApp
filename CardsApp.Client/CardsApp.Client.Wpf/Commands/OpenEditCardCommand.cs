using CardsApp.Client.Wpf.Models;
using CardsApp.Client.Wpf.Stores;
using CardsApp.Client.Wpf.ViewModels;

namespace CardsApp.Client.Wpf.Commands;

public class OpenEditCardCommand: CommandBase
{
    private readonly CardsListItemViewModel cardsListItemViewModel;
    private readonly CardsStore cardsStore;
    private readonly ModalNavigationStore modalNavigationStore;


    public OpenEditCardCommand(CardsListItemViewModel cardsListItemViewModel, CardsStore cardsStore, ModalNavigationStore modalNavigationStore)
    {
        this.cardsListItemViewModel = cardsListItemViewModel;
        this.cardsStore = cardsStore;
        this.modalNavigationStore = modalNavigationStore;
    }

    public override void Execute(object? parameter)
    {
        var cardModel = cardsListItemViewModel.CardModel;
        
        this.modalNavigationStore.CurrentViewModel = new EditCardViewModel(cardModel, cardsStore, modalNavigationStore);
    }
    
}