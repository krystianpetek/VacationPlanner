using System.Windows.Input;
using VacationPlannerWPFApp.Command.HomeApp;

namespace VacationPlannerWPFApp.ViewModels.HomeApp
{
    public class MainScreenViewModels : BaseViewModels
    {
        private BaseViewModels _selectedViewModel = new HomeAppViewModel();
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

        public MainScreenViewModels()
        {
            UpdateViewCommand = new HomeAppViewCommand(this);
        }
    }
}
