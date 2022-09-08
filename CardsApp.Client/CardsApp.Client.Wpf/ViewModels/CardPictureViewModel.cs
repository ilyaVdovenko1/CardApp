namespace CardsApp.Client.Wpf.ViewModels;

public class CardPictureViewModel : ViewModelBase
{
    public string PictureUrl { get; }

    public CardPictureViewModel()
    {
        PictureUrl = @"C:\Users\Lenovo\Desktop\mems\photo_2022-08-28_01-42-41.jpg";
    }
    
}