using System;
using System.Linq;
using System.Windows.Input;
using VacationPlannerWPFApp.Command;
using VacationPlannerWPFApp.Services;
using VacationPlannerWPFApp.Stores;
using VacationPlannerWPFApp.ViewModels.NavigationBars;
using VacationPlannerWPFApp.ViewModels.Employee;

namespace VacationPlannerWPFApp.ViewModels;

public class EmployeeViewModel : ViewModelBase
{
    private readonly DayOffRequestsStore _dayOffRequestsStore;
    private readonly EmployeeStore _employeeStore;

    public EmployeeViewModel(
        EmployeeNavigationBarViewModel navigationBarViewModel,
        NavigationService<AddRequestDayOffViewModel> addRequestDayOffService, 
        NavigationService<ShowAllRequestsViewModel> showAllRequestsService,
        EmployeeStore employeeInfo,
        DayOffRequestsStore dayOffRequestsStore)
    {
        NavigationBarViewModel = navigationBarViewModel;
        _employeeStore = employeeInfo;
        _dayOffRequestsStore = dayOffRequestsStore;
        NavigateAddRequestDayOffCommand = new NavigateCommand<AddRequestDayOffViewModel>(addRequestDayOffService);
        NavigateShowAllRequestsCommand = new NavigateCommand<ShowAllRequestsViewModel>(showAllRequestsService);
    }

    public ICommand NavigateAddRequestDayOffCommand { get; }
    public ICommand NavigateShowAllRequestsCommand { get; }

    public EmployeeNavigationBarViewModel NavigationBarViewModel { get; }

    public string FirstName
    {
        get => _employeeStore.AboutEmployee.FirstName;
        set => _employeeStore.AboutEmployee.FirstName = value;
    }

    public string LastName
    {
        get => _employeeStore.AboutEmployee.LastName;
        set => _employeeStore.AboutEmployee.LastName = value;
    }

    public int AvailableNumberOfDays
    {
        get => _employeeStore.AboutEmployee.AvailableNumberOfDays;
        set => _employeeStore.AboutEmployee.AvailableNumberOfDays = value;
    }

    public bool IsAvailableDays => _employeeStore.AboutEmployee.AvailableNumberOfDays > 0;

    public string TodayDate => DateTime.Now.ToShortDateString();

    public bool IsTodayDayOff =>
        _dayOffRequestsStore.dayOffRequests.Where(q => q.DayOffRequestDate.ToShortDateString() == DateTime.Now.ToShortDateString()).Any();
}