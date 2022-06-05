using System.Windows.Input;
using VacationPlannerWPFApp.Command;
using VacationPlannerWPFApp.Stores;

namespace VacationPlannerWPFApp.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public ICommand NavigateHomeCommand { get; }

        public HomeViewModel(NavigationStore navigationStore)
        {
            NavigateHomeCommand = new NavigateHomeCommand(navigationStore);
        }
    }
}
