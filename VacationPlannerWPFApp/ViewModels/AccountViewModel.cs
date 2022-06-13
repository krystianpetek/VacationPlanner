using System;
using System.Windows.Input;
using VacationPlannerWPFApp.Command;
using VacationPlannerWPFApp.Services;
using VacationPlannerWPFApp.Stores;
using VacationPlannerWPFApp.ViewModels.NavigationBars;

namespace VacationPlannerWPFApp.ViewModels
{
    public class AccountViewModel : ViewModelBase
    {
        private readonly AccountStore _accountStore;
        public ICommand NavigateCommand { get; }

        public Guid Id => _accountStore.CurrentAccount.Id;
        public string Username => _accountStore.CurrentAccount?.Username;
        public string Role => _accountStore.CurrentAccount?.Role;
        public INavigationBar NavigationBarViewModel { get; }

        public AccountViewModel(AdminNavigationBarViewModel aNavigationBarViewModel, EmployeeNavigationBarViewModel eNavigationBarViewModel, AccountStore accountStore, NavigationService<EmployeeViewModel> homeNavigationService)
        {
            _accountStore = accountStore;
            if (_accountStore.CurrentAccount.Role == "Administrator")
                NavigationBarViewModel = aNavigationBarViewModel;
            else
                NavigationBarViewModel = eNavigationBarViewModel;

            NavigateCommand = new NavigateCommand<EmployeeViewModel>(homeNavigationService);
        }
    }
}
