using System.Windows.Input;
using VacationPlannerWPFApp.Command;
using VacationPlannerWPFApp.Command.Login;
using VacationPlannerWPFApp.Models;
using VacationPlannerWPFApp.Services;
using VacationPlannerWPFApp.ViewModels.NavigationBars;

namespace VacationPlannerWPFApp.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        private RegisterModel registerModel = new RegisterModel();
        public RegisterNavigationBarViewModel NavigationBarViewModel { get; }
        public ICommand NavigateCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

        public RegisterViewModel(RegisterNavigationBarViewModel _registerNavigationBarViewModel, NavigationService<EmployeeViewModel> homeNavigationService)
        {
            NavigationBarViewModel = _registerNavigationBarViewModel;

            RegisterCommand = new RegisterCommand(this);

            NavigateCommand = new NavigateCommand<EmployeeViewModel>(homeNavigationService);
        }

        public string CompanyName
        {
            get => registerModel.CompanyName!;
            set
            {
                registerModel.CompanyName = value;
            }
        }

        public string Username
        {
            get => registerModel.Username!;
            set
            {
                registerModel.Username = value;
            }
        }

        public string Password
        {
            get => registerModel.Password!;
            set
            {
                registerModel.Password = value;
            }
        }
        public string Info
        {
            get => registerModel.Info!;
            set
            {
                registerModel.Info = value;
                OnPropertyChanged(nameof(Info));
            }
        }
    }
}
