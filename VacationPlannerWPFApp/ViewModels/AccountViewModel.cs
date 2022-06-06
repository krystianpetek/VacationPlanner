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

        public Guid Id => _accountStore.CurrentAccount.Id = default;
        public string Username => _accountStore.CurrentAccount?.Username;
        public string Role => _accountStore.CurrentAccount?.Role;
        public EmployeeNavigationBarViewModel NavigationBarViewModel { get; }

        public AccountViewModel(EmployeeNavigationBarViewModel navigationBarViewModel, AccountStore accountStore, NavigationService<EmployeeViewModel> homeNavigationService)
        {
            _accountStore = accountStore;
            NavigationBarViewModel = navigationBarViewModel;

            NavigateCommand = new NavigateCommand<EmployeeViewModel>(homeNavigationService);
        }
    }
}
