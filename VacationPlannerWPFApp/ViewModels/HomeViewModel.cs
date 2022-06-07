using System.Windows.Input;
using VacationPlannerWPFApp.Command;
using VacationPlannerWPFApp.Services;
using VacationPlannerWPFApp.ViewModels.NavigationBars;

namespace VacationPlannerWPFApp.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public ICommand NavigateLoginCommand { get; }
        public ICommand NavigateRegisterCommand { get; }

        public HomeNavigationBarViewModel NavigationBarViewModel { get; }

        public HomeViewModel(HomeNavigationBarViewModel navigationBarViewModel, NavigationService<LoginViewModel> loginNavigationService, NavigationService<RegisterViewModel> registerNavigationService)
        {
            NavigationBarViewModel = navigationBarViewModel;

            NavigateLoginCommand = new NavigateCommand<LoginViewModel>(loginNavigationService);
            NavigateRegisterCommand = new NavigateCommand<RegisterViewModel>(registerNavigationService);
        }
    }
}
