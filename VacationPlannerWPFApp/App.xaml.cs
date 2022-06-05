using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using VacationPlannerWPFApp.Models.HomeApp;
using VacationPlannerWPFApp.Stores;
using VacationPlannerWPFApp.ViewModels;

namespace VacationPlannerWPFApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public const string key = "mojSekretnyKluczAPI";
        protected override void OnStartup(StartupEventArgs e)
        {
            NavigationStore navigationStore = new NavigationStore();
            navigationStore.CurrentViewModel = new HomeViewModel(navigationStore);
            MainWindow = new MainScreen()
            {
                DataContext = new MainViewModel(navigationStore)
            };
            MainWindow.Show();
            
        }
    }

}
