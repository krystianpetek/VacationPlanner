using System.Windows.Input;
using VacationPlannerWPFApp.Command.Login;
using VacationPlannerWPFApp.Models.Login;

namespace VacationPlannerWPFApp.ViewModels.Login
{
    public class RegisterViewModel : BaseViewModels
    {
        private RegisterModel registerModel;

        public RegisterViewModel()
        {
            RegisterCommand = new RegisterCommand(this);
            registerModel = new RegisterModel();
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
        public ICommand RegisterCommand { get; set; }
    }
}
