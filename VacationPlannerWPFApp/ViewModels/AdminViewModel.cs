using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VacationPlannerWPFApp.Command;
using VacationPlannerWPFApp.Services;
using VacationPlannerWPFApp.Stores;
using VacationPlannerWPFApp.ViewModels.NavigationBars;

namespace VacationPlannerWPFApp.ViewModels
{
    public class AdminViewModel : ViewModelBase
    {
        public ICommand RedirectCommand { get; }

        public EmployeeNavigationBarViewModel NavigationBarViewModel { get; }

        public AdminViewModel(EmployeeNavigationBarViewModel navigationBarViewModel, AccountStore accountStore)
        {
            NavigationBarViewModel = navigationBarViewModel;
        }
    }
}
