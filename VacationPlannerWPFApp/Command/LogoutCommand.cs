using VacationPlannerWPFApp.Services;
using VacationPlannerWPFApp.Stores;

namespace VacationPlannerWPFApp.Command;

public class LogoutCommand : CommandBase
{
    private readonly AccountStore _accountStore;
    private readonly INavigationService _navigationService;

    public LogoutCommand(AccountStore accountStore, INavigationService navigationService)
    {
        _navigationService = navigationService;
        _accountStore = accountStore;
    }

    public override void Execute(object? parameter)
    {
        _navigationService.Navigate();
        _accountStore.Logout();
    }
}