using System.Windows.Input;
using VacationPlannerWPFApp.Command.Login;
using VacationPlannerWPFApp.Models.Login;

namespace VacationPlannerWPFApp.ViewModels.Login
{
    public class LoginViewModel :BaseViewModels
    {
        
        private LoginModel loginModel;

        public LoginViewModel()
        {
            LoginCommand = new LoginCommand(this);
            loginModel = new LoginModel();
        }

        public string Login
        {
            get => loginModel.Login!;
            set
            {
                loginModel.Login = value;
                OnPropertyChanged(nameof(Login));
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
        public ICommand LoginCommand { get; set; }
    }
}
