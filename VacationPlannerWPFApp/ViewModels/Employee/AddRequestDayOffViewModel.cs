using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationPlannerWPFApp.Stores;
using VacationPlannerWPFApp.ViewModels.NavigationBars;

namespace VacationPlannerWPFApp.ViewModels.Employee
{
    public class AddRequestDayOffViewModel : ViewModelBase
    {
        public EmployeeNavigationBarViewModel NavigationBarViewModel { get; set; }
        private readonly EmployeeStore _employeeStore;
        private readonly DayOffRequestsStore _dayOffRequestsStore;
        public AddRequestDayOffViewModel(EmployeeNavigationBarViewModel navigationBar, EmployeeStore employeeStore, DayOffRequestsStore dayOffRequestsStore)
        {
            NavigationBarViewModel = navigationBar;
            _employeeStore = employeeStore;
            _dayOffRequestsStore = dayOffRequestsStore;
        }
    }
}
