using System;
using System.ComponentModel.DataAnnotations;

namespace VacationPlannerWPFApp.Models.Admin;

public class AdminAddEmployeeModel
{
    [Required] public Guid CompanyId { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string GeneratePassword { get; set; }
    public bool WorkMoreThan10Years { get; set; }
    public int AvailableNumberOfDays { get; set; }
    public int NumberOfDays { get; set; } = 20;
}