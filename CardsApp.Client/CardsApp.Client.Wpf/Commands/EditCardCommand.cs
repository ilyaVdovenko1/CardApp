using System;
using System.Threading.Tasks;
using CardsApp.Client.Domain.Models;
using CardsApp.Client.Wpf.Stores;
using CardsApp.Client.Wpf.ViewModels;

namespace CardsApp.Client.Wpf.Commands;

public class EditCardCommand : AsyncCommandBase
{
    private readonly EditCardViewModel editCardViewModel;
    private readonly CardsStore cardsStore;
    private readonly ModalNavigationStore modalNavigationStore;


    public EditCardCommand(EditCardViewModel editCardViewModel, CardsStore cardsStore,
        ModalNavigationStore modalNavigationStore)
    {
        this.editCardViewModel = editCardViewModel;
        this.cardsStore = cardsStore;
        this.modalNavigationStore = modalNavigationStore;
    }
    public override async Task ExecuteAsync(object? parameter)
    {
        try
        {
            await this.cardsStore.Update(new Card(editCardViewModel.Id, editCardViewModel.CardDetailsFormViewModel.ProductName,
                editCardViewModel.CardDetailsFormViewModel.PictureUrl));
            modalNavigationStore.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
}