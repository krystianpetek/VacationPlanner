using System.Windows.Input;
using VacationPlannerWPFApp.Command;
using VacationPlannerWPFApp.Services;
using VacationPlannerWPFApp.Stores;

namespace VacationPlannerWPFApp.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public ICommand NavigateCommand { get; }

        public HomeNavigationBarViewModel NavigationBarViewModel { get; }

        public HomeViewModel(HomeNavigationBarViewModel navigationBarViewModel, NavigationService<LoginViewModel> loginNavigationService)
        {
            NavigationBarViewModel = navigationBarViewModel;

            NavigateCommand = new NavigateCommand<LoginViewModel>(loginNavigationService);
        }
    }
}
