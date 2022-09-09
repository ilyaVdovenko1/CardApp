using System;
using System.Windows.Input;
using CardsApp.Client.Wpf.Stores;
using CardsApp.Client.Wpf.ViewModels;

namespace CardsApp.Client.Wpf.Commands;

public class OpenAddCardCommand: CommandBase
{
    private readonly CardsStore cardsStore;
    private readonly ModalNavigationStore modalNavigationStore;

    public OpenAddCardCommand(CardsStore cardsStore, ModalNavigationStore modalNavigationStore)
    {
        this.cardsStore = cardsStore;
        this.modalNavigationStore = modalNavigationStore;
    }

    public override void Execute(object? parameter)
    {
        this.modalNavigationStore.CurrentViewModel = new AddCardViewModel(cardsStore, modalNavigationStore);
    }
    
}