using CardsApp.Client.Wpf.Stores;

namespace CardsApp.Client.Wpf.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly ModalNavigationStore modalNavigationStore;

    public ViewModelBase CurrentModalViewModel => modalNavigationStore.CurrentViewModel;
    
    public bool IsModalOpen => modalNavigationStore.IsOpen;

    public MainViewModel(ModalNavigationStore modalNavigationStore, CardsViewModel cardsViewModel)
    {
        this.modalNavigationStore = modalNavigationStore;
        CardsViewModel = cardsViewModel;
        this.modalNavigationStore.SelectedViewModelChanged += ModalNavigationStoreOnSelectedViewModelChanged;
    }

    protected override void UnSubscribe()
    {
        this.modalNavigationStore.SelectedViewModelChanged -= ModalNavigationStoreOnSelectedViewModelChanged;
        
        base.UnSubscribe();
    }

    private void ModalNavigationStoreOnSelectedViewModelChanged()
    {
        OnPropertyChanged(nameof(CurrentModalViewModel));
        OnPropertyChanged(nameof(IsModalOpen));
    }

    public CardsViewModel CardsViewModel { get; }
}