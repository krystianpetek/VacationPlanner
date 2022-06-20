using System;
using System.Windows.Input;
using VacationPlannerWPFApp.Command;
using VacationPlannerWPFApp.Services;
using VacationPlannerWPFApp.Stores;
using VacationPlannerWPFApp.ViewModels.Admin;
using VacationPlannerWPFApp.ViewModels.NavigationBars;

namespace VacationPlannerWPFApp.ViewModels;

/// <summary>
/// Administrator view, contains definitions of all functions that have administrator
/// </summary>
public class AdminViewModel : ViewModelBase
{
    private readonly AdminStore _adminStore;

    /// <summary>
    /// Constructor for AdminViewModel
    /// </summary>
    /// <param name="navigationBarViewModel">Initialization Administrator NavigationBar View</param>
    /// <param name="adminAddEmployeeViewModel">AdminViewModel to binding with AdminView</param>
    /// <param name="showEmployeeRequestsViewModel">ViewModel to Employee requests</param>
    /// <param name="showEmployeesViewModel">ViewModel to Employees</param>
    /// <param name="adminStore">Store administrator information</param>
    public AdminViewModel(AdminNavigationBarViewModel navigationBarViewModel,
        NavigationService<AdminAddEmployeeViewModel> adminAddEmployeeViewModel,
        NavigationService<ShowEmployeeRequestsViewModel> showEmployeeRequestsViewModel, 
        NavigationService<ShowEmployeesViewModel> showEmployeesViewModel, 
        AdminStore adminStore)
    {
        _adminStore = adminStore;
        NavigationBarViewModel = navigationBarViewModel;
        NavigateAddEmployeeComand = new NavigateCommand<AdminAddEmployeeViewModel>(adminAddEmployeeViewModel);
        NavigateShowEmployeesCommand = new NavigateCommand<ShowEmployeesViewModel>(showEmployeesViewModel);
        NavigateShowEmployeeRequestsCommand = new NavigateCommand<ShowEmployeeRequestsViewModel>(showEmployeeRequestsViewModel);
    }

    /// <summary>
    /// Initialization of Navigation bar
    /// </summary>
    public AdminNavigationBarViewModel NavigationBarViewModel { get; }

    /// <summary>
    /// Store Company name
    /// </summary>
    public string CompanyName
    {
        get => _adminStore.AboutAdmin.CompanyName;
        set => _adminStore.AboutAdmin.CompanyName = value;
    }
    /// <summary>
    /// Show today date
    /// </summary>
    public string TodayDate => DateTime.Now.ToShortDateString();

    /// <summary>
    /// Command to Add Employee
    /// </summary>
    public ICommand NavigateAddEmployeeComand { get; }

    /// <summary>
    /// Command to Show Employees
    /// </summary>
    public ICommand NavigateShowEmployeesCommand { get; }

    /// <summary>
    /// Command to show employee requests
    /// </summary>
    public ICommand NavigateShowEmployeeRequestsCommand { get; }
}