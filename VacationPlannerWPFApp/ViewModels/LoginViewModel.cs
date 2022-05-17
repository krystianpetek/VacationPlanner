using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VacationPlannerWPFApp.Command;
using VacationPlannerWPFApp.Models;
using WPFUI.Common;

namespace VacationPlannerWPFApp.ViewModels
{
    public class LoginViewModel :BaseViewModels
    {
        
        private LoginModel loginModel;

        public LoginViewModel()
        {
            LoginCommand = new LoginCommand(this);
            this.loginModel = new LoginModel();
        }

        public string Login
        {
            get
            {
                return this.loginModel.Login;
            }
            set
            {
                this.loginModel.Login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        public string Password
        {
            get
            {
                return this.loginModel.Password;
            }
            set
            {
                this.loginModel.Password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string Info
        {
            get
            {
                return this.loginModel.Info;
            }
            set
            {
                this.loginModel.Info = value;
                OnPropertyChanged(nameof(Info));
            }
        }
        public ICommand LoginCommand { get; set; }
    }
}
