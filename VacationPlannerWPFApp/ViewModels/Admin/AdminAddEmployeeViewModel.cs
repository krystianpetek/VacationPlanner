using System.Windows.Input;
using VacationPlannerWPFApp.Command.Admin;
using VacationPlannerWPFApp.Models.Admin;
using VacationPlannerWPFApp.ViewModels.NavigationBars;

namespace VacationPlannerWPFApp.ViewModels.Admin;

public class AdminAddEmployeeViewModel : ViewModelBase
{
    private readonly AdminAddEmployeeModel adminAddEmployee;

    public AdminAddEmployeeViewModel(AdminNavigationBarViewModel navigationBar)
    {
        NavigationBarViewModel = navigationBar;
        AddEmployeeCommand = new AddEmployeeCommand();
        adminAddEmployee = new AdminAddEmployeeModel();
    }

    public AdminNavigationBarViewModel NavigationBarViewModel { get; }
    public ICommand AddEmployeeCommand { get; }


    public string FirstName
    {
        get => adminAddEmployee.FirstName;
        set => adminAddEmployee.FirstName = value;
    }

    public string LastName
    {
        get => adminAddEmployee.LastName;
        set => adminAddEmployee.LastName = value;
    }

    public string Username
    {
        get => adminAddEmployee.UserName;
        set => adminAddEmployee.UserName = value;
    }

    public int NumberOfDays
    {
        get => adminAddEmployee.NumberOfDays;
        set => adminAddEmployee.NumberOfDays = value;
    }


    public bool WorkMoreThan10Years
    {
        get => adminAddEmployee.WorkMoreThan10Years;
        set
        {
            adminAddEmployee.WorkMoreThan10Years = value;

            if (value)
                NumberOfDays = 26;
            else
                NumberOfDays = 20;
            OnPropertyChanged(nameof(NumberOfDays));
        }
    }

    public int AvailableNumberOfDays
    {
        get => adminAddEmployee.AvailableNumberOfDays;
        set => adminAddEmployee.AvailableNumberOfDays = value;
    }

    public string GeneratePassword
    {
        get => adminAddEmployee.GeneratePassword;
        set => adminAddEmployee.GeneratePassword = value;
    }
}