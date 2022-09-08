using System.Windows.Input;

namespace CardsApp.Client.Wpf.ViewModels;

public class CardDetailsFormViewModel : ViewModelBase
{
    private string productName;

    public CardDetailsFormViewModel(ICommand submitCommand, ICommand cancelCommand)
    {
        SubmitCommand = submitCommand;
        CancelCommand = cancelCommand;
    }

    public string ProductName
    {
        get
        {
            return this.productName;
        }

        set
        {
            this.productName = value;
            OnPropertyChanged(nameof(ProductName));
            OnPropertyChanged(nameof(CanSubmit));
        }

    }
    
    private string pictureUrl;

    public string PictureUrl
    {
        get
        {
            return this.pictureUrl;
        }

        set
        {
            this.pictureUrl = value;
            OnPropertyChanged(nameof(PictureUrl));
            OnPropertyChanged(nameof(CanSubmit));
        }

    }

    public ICommand SubmitCommand { get; }

    public bool CanSubmit => !string.IsNullOrEmpty(ProductName) && !string.IsNullOrEmpty(PictureUrl);
    
    public ICommand CancelCommand { get; }
}