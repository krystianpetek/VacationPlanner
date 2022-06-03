using System.Windows.Input;
using VacationPlannerWPFApp.Command;
using VacationPlannerWPFApp.ViewModels.Login;

namespace VacationPlannerWPFApp.ViewModels
{
    public class MainViewModels : BaseViewModels
    {
        private BaseViewModels _selectedViewModel = new LoginViewModel();
        public BaseViewModels SelectedViewModel
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
            UpdateViewCommand = new LoginViewCommand(this);
        }
    }
}
