using System.Windows.Input;

namespace CardsApp.Client.Wpf.ViewModels;

public class CardsListItemViewModel: ViewModelBase
{
    public string ProductName { get; }
    
    public ICommand EditCommand { get; }
    
    public ICommand DeleteCommand { get; }

    public CardsListItemViewModel(string name)
    {
        ProductName = name;
        
    }
}