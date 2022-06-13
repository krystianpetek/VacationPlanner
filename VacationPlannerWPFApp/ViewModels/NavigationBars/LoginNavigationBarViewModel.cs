using System.Windows.Input;
using VacationPlannerWPFApp.Command;
using VacationPlannerWPFApp.Services;

namespace VacationPlannerWPFApp.ViewModels.NavigationBars;

public class LoginNavigationBarViewModel : ViewModelBase
{
    public LoginNavigationBarViewModel(
        NavigationService<HomeViewModel> homeNavigationService,
        NavigationService<RegisterViewModel> registerNavigationService
    )
    {
        NavigateHomeCommand = new NavigateCommand<HomeViewModel>(homeNavigationService);
        NavigateRegisterCommand = new NavigateCommand<RegisterViewModel>(registerNavigationService);
    }

    public ICommand NavigateHomeCommand { get; }
    public ICommand NavigateRegisterCommand { get; }
}