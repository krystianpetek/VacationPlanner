
using System.Windows.Input;
using VacationPlannerWPFApp.Command;
using VacationPlannerWPFApp.Services;

namespace VacationPlannerWPFApp.ViewModels.NavigationBars
{
    public class RegisterNavigationBarViewModel : ViewModelBase
    {
        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateLoginCommand { get; }

        public RegisterNavigationBarViewModel(
            NavigationService<EmployeeViewModel> homeNavigationService,
            NavigationService<LoginViewModel> loginNavigationService
            )
        {
            NavigateHomeCommand = new NavigateCommand<EmployeeViewModel>(homeNavigationService);
            NavigateLoginCommand = new NavigateCommand<LoginViewModel>(loginNavigationService);
        }
    }

}

