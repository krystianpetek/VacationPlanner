﻿using System;
using System.Threading.Tasks;
using System.Windows.Input;
using VacationPlannerWPFApp.ViewModels;

namespace VacationPlannerWPFApp.Command.Login
{
    public class LoginViewCommand : ICommand
    {
        private LoginViewModel _loginViewModel;
        //private LoginScreenViewModels viewModel;
        //public LoginViewCommand(LoginScreenViewModels viewModel)
        //{
        //    _loginViewModel = new LoginViewModel();
        //    this.viewModel = viewModel;
        //    this.viewModel.SelectedViewModel = _loginViewModel;
        //}

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            //if (parameter!.ToString() == "Register")
            //{
            //    _loginViewModel.Login = String.Empty;
            //    viewModel.SelectedViewModel = new RegisterViewModel();
            //}
            //else if (parameter.ToString() == "Login")
            //    viewModel.SelectedViewModel = _loginViewModel;            
        }
    }
}