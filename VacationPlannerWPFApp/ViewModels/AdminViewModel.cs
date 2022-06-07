using System.Windows.Input;
using VacationPlannerWPFApp.Stores;
using VacationPlannerWPFApp.ViewModels.NavigationBars;

namespace VacationPlannerWPFApp.ViewModels
{
    public class AdminViewModel : ViewModelBase
    {
        private AdminStore _adminStore;
        public AdminNavigationBarViewModel NavigationBarViewModel { get; }

        public AdminViewModel(AdminNavigationBarViewModel navigationBarViewModel, AccountStore accountStore, AdminStore adminStore)
        {
            _adminStore = adminStore;
            NavigationBarViewModel = navigationBarViewModel;
        }

        public string CompanyName
        {
            get => _adminStore.AboutAdmin.CompanyName;
            set
            {
                _adminStore.AboutAdmin.CompanyName = value;
            }
        }
    }
}
