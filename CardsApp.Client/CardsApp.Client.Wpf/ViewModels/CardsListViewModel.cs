using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using CardsApp.Client.Wpf.Commands;
using CardsApp.Client.Domain.Models;
using CardsApp.Client.Wpf.Stores;

namespace CardsApp.Client.Wpf.ViewModels;

public class CardsListViewModel : ViewModelBase
{
    private readonly CardsStore cardsStore;
    private readonly SelectedCardStore selectedCardStore;
    private readonly ModalNavigationStore modalNavigationStore;
    private ObservableCollection<CardsListItemViewModel> cardsListItemView;

    private CardsListItemViewModel selectedCardsListItemViewModel;

    public static CardsListViewModel LoadViewModel(CardsStore cardsStore, SelectedCardStore selectedCardStore,
        ModalNavigationStore modalNavigationStore)
    {
        var viewModel = new CardsListViewModel(cardsStore, selectedCardStore, modalNavigationStore);

        viewModel.LoadCardsCommand.Execute(null);
        
        return viewModel;
    }
    
    public CardsListViewModel(CardsStore cardsStore, SelectedCardStore selectedCardStore,
        ModalNavigationStore modalNavigationStore)
    {
        this.cardsStore = cardsStore;
        this.selectedCardStore = selectedCardStore;
        this.modalNavigationStore = modalNavigationStore;
        this.cardsListItemView = new ObservableCollection<CardsListItemViewModel>();
        this.LoadCardsCommand = new LoadCardsCommand(cardsStore);

        this.cardsStore.CardAdded += CardsStoreOnCardAdded;
        this.cardsStore.CardUpdated += CardsStoreOnCardUpdated;
        this.cardsStore.CardsLoaded += CardsStoreOnCardsLoaded;
        this.cardsStore.CardsDeleted += CardsStoreOnCardsDeleted;

    }
    

    private void CardsStoreOnCardsDeleted(Guid id)
    {
        var cardToDelete = this.cardsListItemView.FirstOrDefault(x => x.CardModel.Id == id);
        if (cardToDelete != null)
        {
            this.cardsListItemView.Remove(cardToDelete);
        }
        
    }

    private void CardsStoreOnCardsLoaded()
    {
        this.cardsListItemView.Clear();
        foreach (var card in cardsStore.Cards)
        {
            AddCard(card);
        }
    }


    public CardsListItemViewModel SelectedCardsListItemViewModel
    {
        get
        {
            return this.selectedCardsListItemViewModel;
        }
        set
        {
            this.selectedCardsListItemViewModel = value;
            OnPropertyChanged(nameof(SelectedCardsListItemViewModel));
            this.selectedCardStore.SelectedCard = this.selectedCardsListItemViewModel?.CardModel;
        }
    }
    
    

    public ICommand LoadCardsCommand { get; }
    

    private void CardsStoreOnCardUpdated(Card card)
    {
        var cardModel = this.cardsListItemView.FirstOrDefault(x => x.CardModel.Id == card.Id);
        cardModel?.Update(card);
    }

    private void CardsStoreOnCardAdded(Card card)
    {
        AddCard(card);
    }

    protected override void UnSubscribe()
    {
        this.cardsStore.CardAdded -= CardsStoreOnCardAdded;
        this.cardsStore.CardUpdated -= CardsStoreOnCardUpdated;
        this.cardsStore.CardsLoaded -= CardsStoreOnCardsLoaded;
        base.UnSubscribe();
    }

    private void AddCard(Card card)
    {
        ICommand editCommand = new OpenEditCardCommand(selectedCardsListItemViewModel, cardsStore, modalNavigationStore);
        this.cardsListItemView.Add(new (card, cardsStore, modalNavigationStore));
    }

    public IEnumerable<CardsListItemViewModel> CardsListItemViewModels => cardsListItemView;
    

}