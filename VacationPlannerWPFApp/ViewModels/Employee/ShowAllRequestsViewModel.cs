using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationPlannerWPFApp.Models;
using VacationPlannerWPFApp.Stores;
using VacationPlannerWPFApp.ViewModels.NavigationBars;

namespace VacationPlannerWPFApp.ViewModels.Employee
{
    public class ShowAllRequestsViewModel : ViewModelBase
    {
        public EmployeeNavigationBarViewModel NavigationBarViewModel { get; }
        private readonly EmployeeStore _employeeStore;
        private readonly DayOffRequestsStore _dayOffRequestsStore;
        public ShowAllRequestsViewModel(EmployeeNavigationBarViewModel navigationBar, EmployeeStore employeeStore, DayOffRequestsStore dayOffRequestsStore)
        {
            NavigationBarViewModel = navigationBar;
            _employeeStore = employeeStore;
            _dayOffRequestsStore = dayOffRequestsStore;
        }

        public IEnumerable<DayOffRequest> EmployeeDayOffRequests
        {
            get { return _dayOffRequestsStore.dayOffRequests; }
        }
    }
}
