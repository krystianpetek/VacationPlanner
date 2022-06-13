using System.Windows.Input;
using VacationPlannerWPFApp.Command;
using VacationPlannerWPFApp.Services;

namespace VacationPlannerWPFApp.ViewModels.NavigationBars;

public class RegisterNavigationBarViewModel : ViewModelBase
{
    public RegisterNavigationBarViewModel(
        NavigationService<HomeViewModel> homeNavigationService,
        NavigationService<LoginViewModel> loginNavigationService
    )
    {
        NavigateHomeCommand = new NavigateCommand<HomeViewModel>(homeNavigationService);
        NavigateLoginCommand = new NavigateCommand<LoginViewModel>(loginNavigationService);
    }

    public ICommand NavigateHomeCommand { get; }
    public ICommand NavigateLoginCommand { get; }
}