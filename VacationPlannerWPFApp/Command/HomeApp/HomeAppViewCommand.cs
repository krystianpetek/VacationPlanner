using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VacationPlannerWPFApp.ViewModels.HomeApp;

namespace VacationPlannerWPFApp.Command.HomeApp
{
    internal class HomeAppViewCommand : ICommand
    {
        private HomeAppViewModel homeAppViewModel;
        private MainScreenViewModels viewModel;
        public HomeAppViewCommand(MainScreenViewModels viewModel)
        {
            homeAppViewModel = new HomeAppViewModel();
            this.viewModel = viewModel;
            this.viewModel.SelectedViewModel = homeAppViewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
        //    if (parameter!.ToString() == "Register")
        //    {
        //        _loginViewModel.Login = String.Empty;
        //        viewModel.SelectedViewModel = new RegisterViewModel();
        //    }
        //    else if (parameter.ToString() == "Login")
        //        viewModel.SelectedViewModel = _loginViewModel;
       }
    }
}
