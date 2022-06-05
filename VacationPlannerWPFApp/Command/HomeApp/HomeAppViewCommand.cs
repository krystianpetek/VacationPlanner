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
        private MainScreenViewModels viewModel;
        public HomeAppViewCommand(MainScreenViewModels viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            viewModel.UpdateViewCommand.Execute("Administrator");
        }
    }
}
