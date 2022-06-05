using System.Windows.Input;
using VacationPlannerWPFApp.Command.Login;
using VacationPlannerWPFApp.Models.HomeApp;
using VacationPlannerWPFApp.Models.Login;
using VacationPlannerWPFApp.Services;
using VacationPlannerWPFApp.Stores;

namespace VacationPlannerWPFApp.ViewModels
{
    public class LoginViewModel :ViewModelBase
    {
        NavigationStore _navigationStore;
        
        private LoginModel loginModel = new LoginModel();
        public ICommand LoginCommand { get; set; }

        public LoginViewModel(AccountStore accountStore, NavigationService<AccountViewModel> accountNavigationService)
        {
            LoginCommand = new LoginCommand(this, accountStore, accountNavigationService);
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
