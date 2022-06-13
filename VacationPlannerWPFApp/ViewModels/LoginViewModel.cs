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
        public LoginNavigationBarViewModel NavigationBarViewModel { get; }
        public ICommand LoginCommand { get; set; }

        public LoginViewModel(
            LoginNavigationBarViewModel loginNavigationBarViewModel,
            AccountStore accountStore,
            AdminStore adminStore,
            EmployeeStore employeeStore,
            DayOffRequestsStore dayOffRequestsStore,
            NavigationService<EmployeeViewModel> homeNavigationService,
            NavigationService<AdminViewModel> adminHomeNavigationService)
        {
            NavigationBarViewModel = loginNavigationBarViewModel;
            LoginCommand = new LoginCommand(this, accountStore, homeNavigationService, adminHomeNavigationService, adminStore, employeeStore, dayOffRequestsStore);
        }

        public string Username
        {
            get => loginModel.Username!;
            set
            {
                loginModel.Username = value;
            }
        }

        public string Password
        {
            get => loginModel.Password!;
            set
            {
                loginModel.Password = value;
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
