using System.Windows.Input;
using VacationPlannerWPFApp.Command;
using VacationPlannerWPFApp.Command.Login;
using VacationPlannerWPFApp.Models.Login;
using VacationPlannerWPFApp.Services;

namespace VacationPlannerWPFApp.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        private RegisterModel registerModel = new RegisterModel();
        public ICommand NavigateCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

        public RegisterViewModel(NavigationService<HomeViewModel> homeNavigationService)
        {
            RegisterCommand = new RegisterCommand(this);

            NavigateCommand = new NavigateCommand<HomeViewModel>(homeNavigationService);
        }
        
        public string CompanyName
        {
            get => registerModel.CompanyName!;
            set
            {
                registerModel.CompanyName = value;
                OnPropertyChanged(nameof(CompanyName));
            }
        }
        
        public string Username
        {
            get => registerModel.Username!;
            set
            {
                registerModel.Username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        
        public string Password
        {
            get => registerModel.Password!;
            set
            {
                registerModel.Password = value;
                OnPropertyChanged(nameof(Password));
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
