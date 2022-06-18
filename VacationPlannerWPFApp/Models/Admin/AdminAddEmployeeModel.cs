using System;
using System.ComponentModel.DataAnnotations;

namespace VacationPlannerWPFApp.Models.Admin;

public class AdminAddEmployeeModel
{
    public Guid CompanyId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string UserName { get; set; }

    public string GeneratedPassword { get; set; }

    public string Info { get; set; } = string.Empty;

    public string InfoPass { get; set; } = string.Empty;

    public bool WorkMoreThan10Years { get; set; } = false;

    public int AvailableNumberOfDays { get; set; } = 0;

    public int NumberOfDays { get; set; } = 20;

}