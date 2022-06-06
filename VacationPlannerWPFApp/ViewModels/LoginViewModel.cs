using System.Windows.Input;
using VacationPlannerWPFApp.Command.Login;
using VacationPlannerWPFApp.Models;
using VacationPlannerWPFApp.Services;
using VacationPlannerWPFApp.Stores;
using VacationPlannerWPFApp.ViewModels.NavigationBars;

namespace VacationPlannerWPFApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private LoginModel loginModel = new LoginModel();
        public LoginNavigationBarViewModel LoginNavigationBarViewModel { get; }
        public ICommand LoginCommand { get; set; }

        public LoginViewModel(
            LoginNavigationBarViewModel loginNavigationBarViewModel,
            AccountStore accountStore,
            NavigationService<EmployeeViewModel> homeNavigationService, NavigationService<AdminViewModel> adminHomeNavigationService)
        {
            LoginNavigationBarViewModel = loginNavigationBarViewModel;
            LoginCommand = new LoginCommand(this, accountStore, homeNavigationService, adminHomeNavigationService);
        }

        public string Username
        {
            get => loginModel.Username!;
            set
            {
                loginModel.Username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get => loginModel.Password!;
            set
            {
                loginModel.Password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string Info
        {
            get => loginModel.Info!;
            set
            {
                loginModel.Info = value;
                OnPropertyChanged(nameof(Info));
            }
        }
    }
}
