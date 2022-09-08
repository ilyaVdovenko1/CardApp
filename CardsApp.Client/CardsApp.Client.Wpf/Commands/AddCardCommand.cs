using System;
using System.Threading.Tasks;
using CardsApp.Client.Wpf.Models;
using CardsApp.Client.Wpf.Stores;
using CardsApp.Client.Wpf.ViewModels;

namespace CardsApp.Client.Wpf.Commands;

public class AddCardCommand : AsyncCommandBase
{
    private readonly AddCardViewModel addCardViewModel;
    private readonly CardsStore cardsStore;
    private readonly ModalNavigationStore modalNavigationStore;


    public AddCardCommand(AddCardViewModel addCardViewModel, CardsStore cardsStore,
        ModalNavigationStore modalNavigationStore)
    {
        this.addCardViewModel = addCardViewModel;
        this.cardsStore = cardsStore;
        this.modalNavigationStore = modalNavigationStore;
    }
    public override async Task ExecuteAsync(object? parameter)
    {
        // Add to db.
        try
        {
            await this.cardsStore.Add(new Card(Guid.NewGuid(), addCardViewModel.CardDetailsFormViewModel.ProductName,
                addCardViewModel.CardDetailsFormViewModel.PictureUrl));
            modalNavigationStore.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        
    }
}