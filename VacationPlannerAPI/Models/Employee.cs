using System.ComponentModel.DataAnnotations;

namespace VacationPlannerAPI.Models;

public class Employee
{
    [Required, Display(Name = "ID")]
    public int Id { get; set; }

    [Required(ErrorMessage = "First name is required"), Display(Name = "First name")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required"), Display(Name = "Last name")]
    public string LastName { get; set; }


}
