using System.Windows.Input;
using CardsApp.Client.Wpf.Commands;
using CardsApp.Client.Domain.Models;
using CardsApp.Client.Wpf.Stores;

namespace CardsApp.Client.Wpf.ViewModels;

public class CardsListItemViewModel: ViewModelBase
{
    public Card CardModel { get; private set; }
    public string ProductName => CardModel.Name;
    
    public ICommand EditCommand { get; }
    
    public ICommand DeleteCommand { get; }

    public CardsListItemViewModel(Card cardModel, CardsStore cardsStore, ModalNavigationStore modalNavigationStore)
    {
        this.EditCommand = new OpenEditCardCommand(this, cardsStore, modalNavigationStore);

        this.DeleteCommand = new DeleteCardCommand(this, cardsStore);
        
        this.CardModel = cardModel;
    }

    public void Update(Card card)
    {
        CardModel = card;
        
        OnPropertyChanged(nameof(ProductName));
    }
}