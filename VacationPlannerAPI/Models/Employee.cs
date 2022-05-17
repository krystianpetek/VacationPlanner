using System.ComponentModel.DataAnnotations;

namespace VacationPlannerAPI.Models;

public class Employee
{
    [Required, Display(Name = "ID"), Key]
    public int EmployeeId { get; set; }

    [Required(ErrorMessage = "First name is required"), Display(Name = "First name")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required"), Display(Name = "Last name")]
    public string LastName { get; set; }

    public int NumberOfDays { get; set; }

    public int AvailableNumberOfDays { get; set; }

    public virtual User Login { get; set; }
    
    public virtual List<ListOfRequest> listOfRequests { get; set; }
}
