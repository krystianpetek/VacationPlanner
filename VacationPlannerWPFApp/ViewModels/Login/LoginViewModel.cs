using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VacationPlannerWPFApp.Command;
using VacationPlannerWPFApp.Models;
using WPFUI.Common;
using VacationPlannerWPFApp.ViewModels;

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
