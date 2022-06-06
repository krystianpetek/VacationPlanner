
using System.Windows.Input;
using VacationPlannerWPFApp.Command;
using VacationPlannerWPFApp.Services;

namespace VacationPlannerWPFApp.ViewModels.NavigationBars
{
    public class LoginNavigationBarViewModel : ViewModelBase
    {
        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateRegisterCommand { get; }

        public LoginNavigationBarViewModel(
            NavigationService<EmployeeViewModel> homeNavigationService,
            NavigationService<RegisterViewModel> registerNavigationService
            )
        {
            NavigateHomeCommand = new NavigateCommand<EmployeeViewModel>(homeNavigationService);
            NavigateRegisterCommand = new NavigateCommand<RegisterViewModel>(registerNavigationService);
        }
    }

}
