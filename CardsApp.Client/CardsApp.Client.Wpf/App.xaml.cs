using System;
using System.IO;
using System.Windows;
using CardsApp.Client.Domain.Services;
using CardsApp.Client.Wpf.Stores;
using CardsApp.Client.Wpf.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CardsApp.Client.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private SelectedCardStore selectedCardStore;
        
        private ModalNavigationStore modalNavigationStore;

        private CardsStore cardsStore;
        
        private ServiceProvider serviceProvider;
        
        public IConfiguration Configuration { get; private set; }
        

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
            
        }
        
        private void ConfigureServices(ServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile(@"appsettings.json", optional: false, reloadOnChange: true);
 
            Configuration = builder.Build();
            

            this.cardsStore = new CardsStore(services.AddCardsAppService(Configuration));
            this.selectedCardStore = new SelectedCardStore();
            this.modalNavigationStore = new ModalNavigationStore();
            
            services.AddSingleton<MainWindow>(new MainWindow()
            {
                DataContext = new MainViewModel(this.modalNavigationStore,new CardsViewModel(this.cardsStore ,this.selectedCardStore, this.modalNavigationStore)),
            });
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}