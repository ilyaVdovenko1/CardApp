using System;
using CardsApp.Client.Wpf.Models;

namespace CardsApp.Client.Wpf.Stores;

public class SelectedCardStore
{
    private Card? selectedCard;

    public Card? SelectedCard
    {
        get
        {
            return this.selectedCard;
        }

        set
        {
            this.selectedCard = value;
            SelectedCardChanged?.Invoke();
        }
    }

    public event Action? SelectedCardChanged;
}