using System.Windows.Input;
using VacationPlannerWPFApp.Command.Login;

namespace VacationPlannerWPFApp.ViewModels.Login
{
    public class LoginScreenViewModels : BaseViewModels
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

        public LoginScreenViewModels()
        {
            UpdateViewCommand = new LoginViewCommand(this);
        }
    }
}
