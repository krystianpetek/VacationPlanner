
using System.Windows.Input;
using VacationPlannerWPFApp.Command;
using VacationPlannerWPFApp.Services;

namespace VacationPlannerWPFApp.ViewModels
{
    public class LoginNavigationBarViewModel : ViewModelBase
    {
        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateRegisterCommand { get; }
    
        public LoginNavigationBarViewModel(
            NavigationService<HomeViewModel> homeNavigationService,
            NavigationService<RegisterViewModel> registerNavigationService
            )
        {
            NavigateHomeCommand = new NavigateCommand<HomeViewModel>(homeNavigationService);
            NavigateRegisterCommand = new NavigateCommand<RegisterViewModel>(registerNavigationService);
        }
    }

}
