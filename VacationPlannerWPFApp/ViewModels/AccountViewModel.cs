using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VacationPlannerWPFApp.Command;
using VacationPlannerWPFApp.Services;
using VacationPlannerWPFApp.Stores;

namespace VacationPlannerWPFApp.ViewModels
{
    public class AccountViewModel : ViewModelBase
    {
        public ICommand NavigateCommand { get; }

        public AccountViewModel(NavigationStore navigationStore)
        {
            NavigateCommand = new NavigateCommand<HomeViewModel>(
                new NavigationService<HomeViewModel>(navigationStore,
                () => new HomeViewModel(navigationStore)));
        }
    }
}
