using CardsApp.Client.Wpf.Models;
using CardsApp.Client.Wpf.Stores;

namespace CardsApp.Client.Wpf.ViewModels;

public class CardPictureViewModel : ViewModelBase
{
    private const string FallbackPath = @"C:\Users\Lenovo\Documents\Texode\CardApp\CardsApp.Client\CardsApp.Client.Wpf\Resources\No_image_available.svg.png";
    
    private SelectedCardStore selectedCardStore;
    private Card? SelectedCard => this.selectedCardStore.SelectedCard;

    public bool HasSelectedCard => SelectedCard != null;
    
    public string PictureUrl => selectedCardStore.SelectedCard?.PictureUrl ?? FallbackPath;

    public CardPictureViewModel(SelectedCardStore selectedCardStore)
    {
        this.selectedCardStore = selectedCardStore;
        this.selectedCardStore.SelectedCardChanged += SelectedCardStoreOnSelectedCardChanged; 
    }

    protected override void UnSubscribe()
    {
        this.selectedCardStore.SelectedCardChanged -= SelectedCardStoreOnSelectedCardChanged;
        base.UnSubscribe();
    }

    private void SelectedCardStoreOnSelectedCardChanged()
    {
        OnPropertyChanged(nameof(PictureUrl));
        OnPropertyChanged(nameof(HasSelectedCard));
        
    }
}