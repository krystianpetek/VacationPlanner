using VacationPlannerWPFApp.Models;

namespace VacationPlannerWPFApp.Stores;

public class AccountStore
{
    public AccountModel CurrentAccount { get; set; }

    public bool IsLoggedIn => CurrentAccount != null;
    public bool IsLoggedOut => CurrentAccount == null;

    public void Logout()
    {
        CurrentAccount = null;
    }
}