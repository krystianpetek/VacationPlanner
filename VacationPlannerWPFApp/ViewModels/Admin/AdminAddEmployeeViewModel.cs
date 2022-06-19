using System;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;
using VacationPlannerWPFApp.Command.Admin;
using VacationPlannerWPFApp.Models.Admin;
using VacationPlannerWPFApp.Stores;
using VacationPlannerWPFApp.ViewModels.NavigationBars;

namespace VacationPlannerWPFApp.ViewModels.Admin;

public class AdminAddEmployeeViewModel : ViewModelBase
{
    private readonly AdminAddEmployeeModel adminAddEmployee;

    public AdminAddEmployeeViewModel(AdminNavigationBarViewModel navigationBar, AdminStore adminStore)
    {
        NavigationBarViewModel = navigationBar;
        adminAddEmployee = new AdminAddEmployeeModel();
        adminAddEmployee.CompanyId = adminStore.AboutAdmin.CompanyId;
        AddEmployeeCommand = new AddEmployeeCommand(adminAddEmployee,this); 
    }

    public AdminNavigationBarViewModel NavigationBarViewModel { get; }

    public ICommand AddEmployeeCommand { get; }

    public Guid CompanyId
    {
        get => adminAddEmployee.CompanyId;
        set
        {
            adminAddEmployee.CompanyId = value;
        }
    }
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
    
    public string Message
    {
        get => adminAddEmployee.Info;
        set 
        { 
            adminAddEmployee.Info = value;
            OnPropertyChanged(nameof(Message));
            OnPropertyChanged(nameof(adminAddEmployee.Info));
        } 
    }

    public string MessagePassword
    {
        get => adminAddEmployee.InfoPass;
        set 
        { 
            adminAddEmployee.InfoPass = value;
            OnPropertyChanged(nameof(MessagePassword));
            OnPropertyChanged(nameof(adminAddEmployee.InfoPass));
        } 
    }

    private string _saveInfo;
    public string SaveInfo
    {
        get => _saveInfo;
        set 
        { 
            _saveInfo = value;
            OnPropertyChanged(nameof(SaveInfo));
        } 
    }


    public string GeneratePassword => adminAddEmployee.GeneratedPassword;
}