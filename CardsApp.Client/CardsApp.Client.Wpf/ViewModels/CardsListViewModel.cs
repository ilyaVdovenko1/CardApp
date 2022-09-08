using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CardsApp.Client.Wpf.ViewModels;

public class CardsListViewModel : ViewModelBase
{
    private readonly ObservableCollection<CardsListItemViewModel> _cardsListItemView;

    public CardsListViewModel()
    {
        _cardsListItemView = new ObservableCollection<CardsListItemViewModel>();
        
        _cardsListItemView.Add(new CardsListItemViewModel("Test1"));
        _cardsListItemView.Add(new CardsListItemViewModel("Test2"));
        _cardsListItemView.Add(new CardsListItemViewModel("Test3"));
        _cardsListItemView.Add(new CardsListItemViewModel("Test4"));
    }

    public IEnumerable<CardsListItemViewModel> CardsListItemViewModels => _cardsListItemView;
    

}