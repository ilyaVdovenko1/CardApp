using System.Windows.Input;
using CardsApp.Client.Wpf.Commands;
using CardsApp.Client.Wpf.Stores;

namespace CardsApp.Client.Wpf.ViewModels;

public class CardsViewModel: ViewModelBase
{
    public CardsViewModel(CardsStore cardsStore, SelectedCardStore selectedCardStore,
        ModalNavigationStore modalNavigationStore)
    {
        CardsListViewModel = CardsListViewModel.LoadViewModel(cardsStore, selectedCardStore, modalNavigationStore);
        CardPictureViewModel = new CardPictureViewModel(selectedCardStore);

        AddCardCommand = new OpenAddCardCommand(cardsStore,modalNavigationStore);
    }

    public CardsListViewModel CardsListViewModel { get; }
    public CardPictureViewModel CardPictureViewModel { get; }
    public ICommand AddCardCommand { get; }
}