using System.Windows.Input;
using VacationPlannerWPFApp.Command;
using VacationPlannerWPFApp.Services;
using VacationPlannerWPFApp.ViewModels.NavigationBars;

namespace VacationPlannerWPFApp.ViewModels
{
    public class EmployeeViewModel : ViewModelBase
    {
        public ICommand NavigateCommand { get; }

        public EmployeeNavigationBarViewModel NavigationBarViewModel { get; }

        public EmployeeViewModel(EmployeeNavigationBarViewModel navigationBarViewModel, NavigationService<LoginViewModel> loginNavigationService)
        {
            NavigationBarViewModel = navigationBarViewModel;

            NavigateCommand = new NavigateCommand<LoginViewModel>(loginNavigationService);
        }
    }
}
