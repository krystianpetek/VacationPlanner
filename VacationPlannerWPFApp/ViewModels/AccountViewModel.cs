using System;
using System.Windows.Input;
using VacationPlannerWPFApp.Command;
using VacationPlannerWPFApp.Services;
using VacationPlannerWPFApp.Stores;
using VacationPlannerWPFApp.ViewModels.NavigationBars;

namespace VacationPlannerWPFApp.ViewModels;

/// <summary>
/// Employee and administrator view, details about the logged account, inherits from ViewModelBase
/// </summary>
public class AccountViewModel : ViewModelBase
{
    private readonly AccountStore _accountStore;

    /// <summary>
    /// Constructor for AccountViewModel
    /// </summary>
    /// <param name="aNavigationBarViewModel">Administrator NavigationBar Views depends on role</param>
    /// <param name="eNavigationBarViewModel">Employee NavigationBar Views depends on role</param>
    /// <param name="accountStore">Store information about account after login like singleton</param>
    /// <param name="homeNavigationService">Initialization command to EmployeeViewModel</param>
    public AccountViewModel(AdminNavigationBarViewModel aNavigationBarViewModel,
        EmployeeNavigationBarViewModel eNavigationBarViewModel, AccountStore accountStore,
        NavigationService<EmployeeViewModel> homeNavigationService)
    {
        _accountStore = accountStore;
        if (_accountStore.CurrentAccount.Role == "Administrator")
            NavigationBarViewModel = aNavigationBarViewModel;
        else
            NavigationBarViewModel = eNavigationBarViewModel;

        NavigateCommand = new NavigateCommand<EmployeeViewModel>(homeNavigationService);
    }

    /// <summary>
    /// Navigate to EmployeeViewModel
    /// </summary>
    public ICommand NavigateCommand { get; }

    /// <summary>
    /// Account ID
    /// </summary>
    public Guid Id => _accountStore.CurrentAccount.Id;

    /// <summary>
    /// Username
    /// </summary>
    public string Username => _accountStore.CurrentAccount?.Username;

    /// <summary>
    /// User role
    /// </summary>
    public string Role => _accountStore.CurrentAccount?.Role;
    
    /// <summary>
    /// Initialization NavigationBar View depends on account role
    /// </summary>
    public INavigationBar NavigationBarViewModel { get; }
}