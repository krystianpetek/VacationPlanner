using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VacationPlannerWPFApp.Command;
using VacationPlannerWPFApp.Models;

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
