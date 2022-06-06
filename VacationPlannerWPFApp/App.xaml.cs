using System.Windows;
using VacationPlannerWPFApp.Services;
using VacationPlannerWPFApp.Stores;
using VacationPlannerWPFApp.ViewModels;
using VacationPlannerWPFApp.ViewModels.NavigationBars;

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
        private readonly EmployeeNavigationBarViewModel _employeeNavigationBarViewModel;
        private readonly LoginNavigationBarViewModel _loginNavigationBarViewModel;
        private readonly RegisterNavigationBarViewModel _registerNavigationBarViewModel;
        private readonly AdminNavigationBarViewModel _adminNavigationBarViewModel;

        public App()
        {
            _accountStore = new AccountStore();
            _navigationStore = new NavigationStore();

            _employeeNavigationBarViewModel = new EmployeeNavigationBarViewModel(
                _accountStore,
                CreateHomeNavigationService(),
                CreateAccountNavigationService(),
                CreateLoginNavigationService()
                );

            _adminNavigationBarViewModel = new AdminNavigationBarViewModel(
                _accountStore,
                CreateHomeNavigationService(),
                CreateAccountNavigationService(),
                CreateLoginNavigationService()
                );

            _loginNavigationBarViewModel = new LoginNavigationBarViewModel(
                CreateHomeNavigationService(),
                CreateRegisterNavigationService());

            _registerNavigationBarViewModel = new RegisterNavigationBarViewModel(
                CreateHomeNavigationService(),
                CreateLoginNavigationService());
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

        private NavigationService<EmployeeViewModel> CreateHomeNavigationService()
        {
            return new NavigationService<EmployeeViewModel>(
                _navigationStore,
                () => new EmployeeViewModel(_employeeNavigationBarViewModel, CreateLoginNavigationService()));
        }

        private NavigationService<AdminViewModel> CreateAdminHomeNavigationService()
        {
            return new NavigationService<AdminViewModel>(
                _navigationStore,
                () => new AdminViewModel(_employeeNavigationBarViewModel, _accountStore));
        }

        private NavigationService<RegisterViewModel> CreateRegisterNavigationService()
        {
            return new NavigationService<RegisterViewModel>(
                _navigationStore,
                () => new RegisterViewModel(_registerNavigationBarViewModel, CreateHomeNavigationService()));
        }

        private NavigationService<LoginViewModel> CreateLoginNavigationService()
        {
            return new NavigationService<LoginViewModel>(
                _navigationStore,
                () => new LoginViewModel(_loginNavigationBarViewModel, _accountStore, CreateHomeNavigationService(),CreateAdminHomeNavigationService()));
        }

        private NavigationService<AccountViewModel> CreateAccountNavigationService()
        {
            return new NavigationService<AccountViewModel>(
                _navigationStore,
                () => new AccountViewModel(_employeeNavigationBarViewModel, _accountStore, CreateHomeNavigationService()));
        }
    }

}
