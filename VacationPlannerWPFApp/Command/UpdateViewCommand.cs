using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VacationPlannerWPFApp.ViewModels;

namespace VacationPlannerWPFApp.Command
{
    public class UpdateViewCommand : ICommand
    {
        private MainViewModels viewModel;
        public UpdateViewCommand(MainViewModels viewModel)
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
            if(parameter.ToString() == "Home")
                viewModel.SelectedViewModel = new HomeViewModels();
            else if(parameter.ToString() == "Home2")
                viewModel.SelectedViewModel = new Home2ViewModels();
        }
    }
}
