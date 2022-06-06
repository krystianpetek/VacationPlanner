using VacationPlannerWPFApp.Models;

namespace VacationPlannerWPFApp.Stores
{
    public class AccountStore
    {
        private AccountModel _currentAccount;

        public AccountModel CurrentAccount
        {
            get => _currentAccount;
            set
            {
                _currentAccount = value;
            }
        }

        public bool IsLoggedIn => CurrentAccount != null;
        public bool IsLoggedOut => CurrentAccount == null;

        public void Logout()
        {
            CurrentAccount = null;
        }

    }
}
