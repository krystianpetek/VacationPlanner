using System.Windows;
using VacationPlannerWPFApp.Services;
using VacationPlannerWPFApp.Stores;
using VacationPlannerWPFApp.ViewModels;
using VacationPlannerWPFApp.ViewModels.Admin;
using VacationPlannerWPFApp.ViewModels.Employee;
using VacationPlannerWPFApp.ViewModels.NavigationBars;

namespace VacationPlannerWPFApp;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public const string key = "mojSekretnyKluczAPI";
    public const string URLToAPI = "localhost:7020";

    private readonly AccountStore _accountStore;
    private readonly AdminNavigationBarViewModel _adminNavigationBarViewModel;
    private readonly AdminStore _adminStore;
    private readonly DayOffRequestsStore _dayOffRequestsStore;
    private readonly EmployeeNavigationBarViewModel _employeeNavigationBarViewModel;
    private readonly EmployeeStore _employeeStore;
    private readonly HomeNavigationBarViewModel _homeNavigationBarViewModel;
    private readonly LoginNavigationBarViewModel _loginNavigationBarViewModel;
    private readonly NavigationStore _navigationStore;
    private readonly RegisterNavigationBarViewModel _registerNavigationBarViewModel;

    public App()
    {
        _accountStore = new AccountStore();
        _adminStore = new AdminStore();
        _employeeStore = new EmployeeStore();
        _dayOffRequestsStore = new DayOffRequestsStore();
        _navigationStore = new NavigationStore();

        _homeNavigationBarViewModel = new HomeNavigationBarViewModel(
            CreateHomeNavigationService(),
            CreateLoginNavigationService()
        );

        _employeeNavigationBarViewModel = new EmployeeNavigationBarViewModel(
            _accountStore,
            CreateEmployeeNavigationService(),
            CreateAccountNavigationService(),
            CreateLoginNavigationService()
        );

        _adminNavigationBarViewModel = new AdminNavigationBarViewModel(
            _accountStore,
            CreateAdminHomeNavigationService(),
            CreateAccountNavigationService(),
            CreateLoginNavigationService()
        );

        _loginNavigationBarViewModel = new LoginNavigationBarViewModel(
            CreateHomeNavigationService(),
            CreateRegisterNavigationService());

        _registerNavigationBarViewModel = new RegisterNavigationBarViewModel(
            CreateHomeNavigationService(),
            CreateLoginNavigationService());
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var homeNavigationService = CreateHomeNavigationService();
        homeNavigationService.Navigate();

        MainWindow = new MainScreen
        {
            DataContext = new MainViewModel(_navigationStore)
        };
        MainWindow.Show();

        base.OnStartup(e);
    }

    private NavigationService<HomeViewModel> CreateHomeNavigationService()
    {
        return new NavigationService<HomeViewModel>(
            _navigationStore,
            () => new HomeViewModel(_homeNavigationBarViewModel, CreateLoginNavigationService(),
                CreateRegisterNavigationService()));
    }

    private NavigationService<EmployeeViewModel> CreateEmployeeNavigationService()
    {
        return new NavigationService<EmployeeViewModel>(
            _navigationStore,
            () => new EmployeeViewModel(_employeeNavigationBarViewModel, CreateAddRequestDayOffService(), CreateShowAllRequestsService(), _employeeStore,
                _dayOffRequestsStore));
    }

    private NavigationService<AdminViewModel> CreateAdminHomeNavigationService()
    {
        return new NavigationService<AdminViewModel>(
            _navigationStore,
            () => new AdminViewModel(_adminNavigationBarViewModel, CreateAdminAddEmployeeNavigationService(), CreateShowEmployeeRequestsNavigationService(), CreateShowEmployeesService(), _adminStore));
    }

    private NavigationService<RegisterViewModel> CreateRegisterNavigationService()
    {
        return new NavigationService<RegisterViewModel>(
            _navigationStore,
            () => new RegisterViewModel(_registerNavigationBarViewModel, CreateEmployeeNavigationService()));
    }

    private NavigationService<LoginViewModel> CreateLoginNavigationService()
    {
        return new NavigationService<LoginViewModel>(
            _navigationStore,
            () => new LoginViewModel(_loginNavigationBarViewModel, _accountStore, _adminStore, _employeeStore,
                _dayOffRequestsStore, CreateEmployeeNavigationService(), CreateAdminHomeNavigationService()));
    }

    private NavigationService<AccountViewModel> CreateAccountNavigationService()
    {
        return new NavigationService<AccountViewModel>(
            _navigationStore,
            () => new AccountViewModel(_adminNavigationBarViewModel, _employeeNavigationBarViewModel, _accountStore,
                CreateEmployeeNavigationService()));
    }


    private NavigationService<AdminAddEmployeeViewModel> CreateAdminAddEmployeeNavigationService()
    {
        return new NavigationService<AdminAddEmployeeViewModel>(
            _navigationStore,
            () => new AdminAddEmployeeViewModel(_adminNavigationBarViewModel,_adminStore));
    }

    private NavigationService<ShowEmployeeRequestsViewModel> CreateShowEmployeeRequestsNavigationService()
    {
        return new NavigationService<ShowEmployeeRequestsViewModel>(
            _navigationStore,
            () => new ShowEmployeeRequestsViewModel(_adminNavigationBarViewModel,_adminStore));
    }

    private NavigationService<ShowEmployeesViewModel> CreateShowEmployeesService()
    {
        return new NavigationService<ShowEmployeesViewModel>(
            _navigationStore,
            () => new ShowEmployeesViewModel(_adminNavigationBarViewModel,_adminStore));
    }

    private NavigationService<AddRequestDayOffViewModel> CreateAddRequestDayOffService()
    {
        return new NavigationService<AddRequestDayOffViewModel>(
            _navigationStore,
            () => new AddRequestDayOffViewModel(_employeeNavigationBarViewModel,_employeeStore, _dayOffRequestsStore));
    }

    private NavigationService<ShowAllRequestsViewModel> CreateShowAllRequestsService()
    {
        return new NavigationService<ShowAllRequestsViewModel>(
            _navigationStore,
            () => new ShowAllRequestsViewModel(_employeeNavigationBarViewModel,_employeeStore, _dayOffRequestsStore));
    }
}