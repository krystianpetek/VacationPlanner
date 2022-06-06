using System.Windows.Input;
using VacationPlannerWPFApp.Stores;
using VacationPlannerWPFApp.ViewModels.NavigationBars;

namespace VacationPlannerWPFApp.ViewModels
{
    public class AdminViewModel : ViewModelBase
    {

        public AdminNavigationBarViewModel NavigationBarViewModel { get; }

        public AdminViewModel(AdminNavigationBarViewModel navigationBarViewModel, AccountStore accountStore)
        {
            NavigationBarViewModel = navigationBarViewModel;
        }
    }
}
