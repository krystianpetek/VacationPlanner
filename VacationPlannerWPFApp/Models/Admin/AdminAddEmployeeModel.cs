using System;
using System.ComponentModel.DataAnnotations;

namespace VacationPlannerWPFApp.Models.Admin;

public class AdminAddEmployeeModel
{
    public Guid CompanyId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string UserName { get; set; }

    public string GeneratedPassword
    {
        get
        {
            Random random = new Random();
            string pass = string.Empty;
            for (int i = 0; i < 16; i++)
            {
                char c = (char)random.Next(33, 126);
                pass += c;
            }
            return pass;
        }
    }

    public string Info { get; set; } = string.Empty;

    public string InfoPass { get; set; } = string.Empty;

    public bool WorkMoreThan10Years { get; set; } = false;

    public int AvailableNumberOfDays { get; set; } = 0;

    public int NumberOfDays { get; set; } = 20;

}