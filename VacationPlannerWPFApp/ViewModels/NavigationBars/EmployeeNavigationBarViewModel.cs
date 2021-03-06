using System.Windows.Input;
using VacationPlannerWPFApp.Command;
using VacationPlannerWPFApp.Services;
using VacationPlannerWPFApp.Stores;

namespace VacationPlannerWPFApp.ViewModels.NavigationBars;

public class EmployeeNavigationBarViewModel : ViewModelBase, INavigationBar
{
    private readonly AccountStore _accountStore;

    public EmployeeNavigationBarViewModel(
        AccountStore accountStore,
        NavigationService<EmployeeViewModel> employeeNavigationService,
        NavigationService<AccountViewModel> accountNavigationService,
        NavigationService<LoginViewModel> loginNavigationService
    )
    {
        _accountStore = accountStore;
        NavigateHomeCommand = new NavigateCommand<EmployeeViewModel>(employeeNavigationService);
        NavigateAccountCommand = new NavigateCommand<AccountViewModel>(accountNavigationService);
        NavigateLoginCommand = new NavigateCommand<LoginViewModel>(loginNavigationService);
        LogoutCommand = new LogoutCommand(_accountStore, loginNavigationService);
    }

    public ICommand NavigateHomeCommand { get; }
    public ICommand NavigateAccountCommand { get; }
    public ICommand NavigateLoginCommand { get; }
    public ICommand LogoutCommand { get; }

    public bool IsLoggedIn => _accountStore.IsLoggedIn;
    public bool IsLoggedOut => _accountStore.IsLoggedOut;
}