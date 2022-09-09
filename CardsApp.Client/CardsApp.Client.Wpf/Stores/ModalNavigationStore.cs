using System;
using CardsApp.Client.Wpf.ViewModels;

namespace CardsApp.Client.Wpf.Stores;

public class ModalNavigationStore
{
    private ViewModelBase? currentViewModel;

    public ViewModelBase? CurrentViewModel
    {
        get
        {
            return this.currentViewModel;
        }

        set
        {
            this.currentViewModel = value;
            SelectedViewModelChanged?.Invoke();
        }
    }

    public bool IsOpen => CurrentViewModel != null;

    public event Action? SelectedViewModelChanged;

    public void Close()
    {
        CurrentViewModel = null;
    }
}