using System;
using System.Windows.Input;
using CardsApp.Client.Wpf.Commands;
using CardsApp.Client.Wpf.Models;
using CardsApp.Client.Wpf.Stores;

namespace CardsApp.Client.Wpf.ViewModels;

public class EditCardViewModel : ViewModelBase
{
    public Guid Id { get;  }
    public CardDetailsFormViewModel CardDetailsFormViewModel { get; }

    public EditCardViewModel(Card card, CardsStore cardsStore, ModalNavigationStore modalNavigationStore)
    {
        this.Id = card.Id;
        ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
        ICommand editCommand = new EditCardCommand(this, cardsStore, modalNavigationStore);
        CardDetailsFormViewModel = new CardDetailsFormViewModel(editCommand, cancelCommand)
        {
            PictureUrl = card.PictureUrl,
            ProductName = card.Name,
            
        };
    }
}