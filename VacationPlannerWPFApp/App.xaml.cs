using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using VacationPlannerWPFApp.Models.HomeApp;
using VacationPlannerWPFApp.Services;
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
        
        private readonly AccountStore _accountStore;
        private readonly NavigationStore _navigationStore;
        private readonly NavigationBarViewModel _navigationBarViewModel;

        public App()
        {
            _accountStore = new AccountStore();
            _navigationStore = new NavigationStore();
            _navigationBarViewModel = new NavigationBarViewModel(
                CreateHomeNavigationService(),
                CreateAccountNavigationService(),
                CreateLoginNavigationService()
                );
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var homeNavigationService = CreateHomeNavigationService();
            homeNavigationService.Navigate();

            MainWindow = new MainScreen()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);            
        }

        private NavigationService<HomeViewModel> CreateHomeNavigationService()
        {
            return new NavigationService<HomeViewModel>(
                _navigationStore,
                () => new HomeViewModel(_navigationBarViewModel, CreateLoginNavigationService()));
        } 
        
        private NavigationService<RegisterViewModel> CreateRegisterNavigationService()
        {
            return new NavigationService<RegisterViewModel>(
                _navigationStore,
                () => new RegisterViewModel(CreateHomeNavigationService()));
        }

        private NavigationService<LoginViewModel> CreateLoginNavigationService()
        {
            return new NavigationService<LoginViewModel>(
                _navigationStore,
                () => new LoginViewModel(CreateRegisterNavigationService(),CreateHomeNavigationService(),_accountStore, CreateAccountNavigationService()));
        }

        private NavigationService<AccountViewModel> CreateAccountNavigationService()
        {
            return new NavigationService<AccountViewModel>(
                _navigationStore,
                () => new AccountViewModel(_navigationBarViewModel, _accountStore, CreateHomeNavigationService()));
        }
    }

}
