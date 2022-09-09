using System.Windows.Input;
using CardsApp.Client.Wpf.Commands;
using CardsApp.Client.Wpf.Stores;

namespace CardsApp.Client.Wpf.ViewModels;

public class AddCardViewModel : ViewModelBase
{
    public CardDetailsFormViewModel CardDetailsFormViewModel { get; }

    public AddCardViewModel(CardsStore cardsStore, ModalNavigationStore modalNavigationStore)
    {
        ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
        ICommand submitCommand = new AddCardCommand(this, cardsStore, modalNavigationStore);
        CardDetailsFormViewModel = new CardDetailsFormViewModel(submitCommand, cancelCommand);
    }
}