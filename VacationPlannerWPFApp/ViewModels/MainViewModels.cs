using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VacationPlannerWPFApp.Command;

namespace VacationPlannerWPFApp.ViewModels
{
    public class MainViewModels : BaseViewModels
    {
        private BaseViewModels _selectedViewModel = new LoginViewModel();
        public  BaseViewModels SelectedViewModel
        {
            get
            {
                return _selectedViewModel;
            }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }
        public ICommand UpdateViewCommand { get; set; }
        public MainViewModels()
        {
            UpdateViewCommand = new UpdateViewCommand(this);
        }
    }
}
