using System.Windows;
using CardsApp.Client.Wpf.Stores;
using CardsApp.Client.Wpf.ViewModels;

namespace CardsApp.Client.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly SelectedCardStore selectedCardStore;
        
        private readonly ModalNavigationStore modalNavigationStore;

        private readonly CardsStore cardsStore;

        public App()
        {
            this.cardsStore = new CardsStore();
            this.selectedCardStore = new SelectedCardStore();
            this.modalNavigationStore = new ModalNavigationStore();
        }
        
        protected override void OnStartup(StartupEventArgs eventArgs)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(this.modalNavigationStore,new CardsViewModel(this.cardsStore ,this.selectedCardStore, this.modalNavigationStore)),
                
            };
            MainWindow.Show();
            
            
        }
    }
}