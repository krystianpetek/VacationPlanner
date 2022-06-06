﻿using System.Windows.Input;
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
        public RegisterNavigationBarViewModel RegisterNavigationBarViewModel { get; }
        public ICommand NavigateCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

        public RegisterViewModel(RegisterNavigationBarViewModel _registerNavigationBarViewModel, NavigationService<EmployeeViewModel> homeNavigationService)
        {
            RegisterNavigationBarViewModel = _registerNavigationBarViewModel;

            RegisterCommand = new RegisterCommand(this);

            NavigateCommand = new NavigateCommand<EmployeeViewModel>(homeNavigationService);
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
