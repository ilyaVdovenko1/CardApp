using System.Windows.Controls;
using CardsApp.Client.Wpf.ViewModels;

namespace CardsApp.Client.Wpf.Components;

public partial class CardDetailsForm : UserControl
{
    public CardDetailsForm()
    {
        DataContext = new OpenFileDialogViewModel();
        InitializeComponent();
    }
}