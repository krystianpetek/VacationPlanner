using System;
using System.Windows.Input;
using VacationPlannerWPFApp.Command;
using VacationPlannerWPFApp.Services;
using VacationPlannerWPFApp.Stores;
using VacationPlannerWPFApp.ViewModels.NavigationBars;

namespace VacationPlannerWPFApp.ViewModels
{
    public class AdminViewModel : ViewModelBase
    {
        private AdminStore _adminStore;
        public AdminNavigationBarViewModel NavigationBarViewModel { get; }

        public AdminViewModel(AdminNavigationBarViewModel navigationBarViewModel, NavigationService<AdminAddEmployeeViewModel> adminAddEmployeeViewModel, AdminStore adminStore)
        {
            _adminStore = adminStore;
            NavigationBarViewModel = navigationBarViewModel;
            NavigateAddEmployeeComand = new NavigateCommand<AdminAddEmployeeViewModel>(adminAddEmployeeViewModel);
        }

        public string CompanyName
        {
            get => _adminStore.AboutAdmin.CompanyName;
            set
            {
                _adminStore.AboutAdmin.CompanyName = value;
            }
        }

        public ICommand NavigateAddEmployeeComand { get; }
        public string TodayDate => DateTime.Now.ToShortDateString();
    }
}
