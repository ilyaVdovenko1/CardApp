using System.Windows.Input;

namespace CardsApp.Client.Wpf.ViewModels;

public class CardsViewModel: ViewModelBase
{
    public CardsViewModel()
    {
        CardsListViewModel = new CardsListViewModel();
        CardPictureViewModel = new CardPictureViewModel();
    }

    public CardsListViewModel CardsListViewModel { get; }

    public CardPictureViewModel CardPictureViewModel { get; }
    
    public ICommand AddCardCommand { get; }
}