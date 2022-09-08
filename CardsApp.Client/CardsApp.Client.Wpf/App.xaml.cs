using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CardsApp.Client.Wpf.ViewModels;

namespace CardsApp.Client.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs eventArgs)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new CardsViewModel(),
                
            };
            MainWindow.Show();
            
            
        }
    }
}