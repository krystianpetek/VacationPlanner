using System;
using System.Windows.Input;
using VacationPlannerWPFApp.Command;
using VacationPlannerWPFApp.Services;
using VacationPlannerWPFApp.Stores;
using VacationPlannerWPFApp.ViewModels.Admin;
using VacationPlannerWPFApp.ViewModels.NavigationBars;

namespace VacationPlannerWPFApp.ViewModels;

public class AdminViewModel : ViewModelBase
{
    private readonly AdminStore _adminStore;

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

    public AdminNavigationBarViewModel NavigationBarViewModel { get; }

    public string CompanyName
    {
        get => _adminStore.AboutAdmin.CompanyName;
        set => _adminStore.AboutAdmin.CompanyName = value;
    }
    public string TodayDate => DateTime.Now.ToShortDateString();

    public ICommand NavigateAddEmployeeComand { get; }
    public ICommand NavigateShowEmployeesCommand { get; }
    public ICommand NavigateShowEmployeeRequestsCommand { get; }
}