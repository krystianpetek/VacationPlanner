using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VacationPlannerWPFApp.Command;
using VacationPlannerWPFApp.Models.HomeApp;
using VacationPlannerWPFApp.Services;
using VacationPlannerWPFApp.Stores;

namespace VacationPlannerWPFApp.ViewModels
{
    public class AccountViewModel : ViewModelBase
    {
        private readonly AccountStore _accountStore;
        public ICommand NavigateCommand { get; }

        public Guid Id => _accountStore.CurrentAccount.Id;
        public string Username => _accountStore.CurrentAccount?.Username;
        public string Role => _accountStore.CurrentAccount?.Role;

        public AccountViewModel(AccountStore accountStore, NavigationStore navigationStore)
        {
            _accountStore = accountStore;

            NavigateCommand = new NavigateCommand<HomeViewModel>(
                new NavigationService<HomeViewModel>(navigationStore,
                () => new HomeViewModel(accountStore, navigationStore)));
        }
    }
}
