using VacationPlannerWPFApp.Services;
using VacationPlannerWPFApp.Stores;
using VacationPlannerWPFApp.ViewModels;

namespace VacationPlannerWPFApp.Command
{
    public class LogoutCommand : CommandBase
    {
        private readonly NavigationService<EmployeeViewModel> _navigationService;
        private readonly AccountStore _accountStore;

        public LogoutCommand(AccountStore accountStore, NavigationService<EmployeeViewModel> navigationService)
        {
            _navigationService = navigationService;
            _accountStore = accountStore;
        }

        public override void Execute(object? parameter)
        {
            _accountStore.Logout();
            _navigationService.Navigate();
        }

    }
}
