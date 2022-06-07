using System;
using System.Windows.Input;
using VacationPlannerWPFApp.Command;
using VacationPlannerWPFApp.Models;
using VacationPlannerWPFApp.Services;
using VacationPlannerWPFApp.Stores;
using VacationPlannerWPFApp.ViewModels.NavigationBars;

namespace VacationPlannerWPFApp.ViewModels
{
    public class EmployeeViewModel : ViewModelBase
    {
        private EmployeeStore _employeeStore;
        public ICommand NavigateCommand { get; }

        public EmployeeNavigationBarViewModel NavigationBarViewModel { get; }

        public EmployeeViewModel(EmployeeNavigationBarViewModel navigationBarViewModel, NavigationService<LoginViewModel> loginNavigationService, EmployeeStore employeeInfo)
        {
            NavigationBarViewModel = navigationBarViewModel;
            _employeeStore = employeeInfo;
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
        public string Today => DateTime.Now.ToShortDateString();
    }
}
