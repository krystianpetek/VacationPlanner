using System;
using System.Linq;
using System.Windows.Input;
using VacationPlannerWPFApp.Command;
using VacationPlannerWPFApp.Services;
using VacationPlannerWPFApp.Stores;
using VacationPlannerWPFApp.ViewModels.NavigationBars;

namespace VacationPlannerWPFApp.ViewModels
{
    public class EmployeeViewModel : ViewModelBase
    {
        private EmployeeStore _employeeStore;
        private DayOffRequestsStore _dayOffRequestsStore;
        public ICommand NavigateCommand { get; }

        public EmployeeNavigationBarViewModel NavigationBarViewModel { get; }

        public EmployeeViewModel(EmployeeNavigationBarViewModel navigationBarViewModel, NavigationService<LoginViewModel> loginNavigationService, EmployeeStore employeeInfo, DayOffRequestsStore dayOffRequestsStore)
        {
            NavigationBarViewModel = navigationBarViewModel;
            _employeeStore = employeeInfo;
            _dayOffRequestsStore = dayOffRequestsStore;
            NavigateCommand = new NavigateCommand<LoginViewModel>(loginNavigationService);
        }

        public string FirstName
        {
            get => _employeeStore.AboutEmployee.FirstName;
            set
            {
                _employeeStore.AboutEmployee.FirstName = value;
            }
        }
        public string LastName
        {
            get => _employeeStore.AboutEmployee.LastName;
            set
            {
                _employeeStore.AboutEmployee.LastName = value;
            }
        }
        public int AvailableNumberOfDays
        {
            get => _employeeStore.AboutEmployee.AvailableNumberOfDays;
            set
            {
                _employeeStore.AboutEmployee.AvailableNumberOfDays = value;
            }
        }

        public bool IsAvailableDays => _employeeStore.AboutEmployee.AvailableNumberOfDays > 0;

        public string TodayDate => DateTime.Now.ToShortDateString();

        public bool IsTodayDayOff => _dayOffRequestsStore.dayOffRequests.Where(q => q.DayOffRequestDate == DateTime.Now).Any();
    }
}
