using System.ComponentModel.DataAnnotations;

namespace VacationPlannerAPI.Models;

public class Employee
{
    [Display(Name = "ID"), Key]
    public Guid Id { get; set; }

    //[Required(ErrorMessage = "First name is required")]
    [Display(Name = "First name")]
    public string FirstName { get; set; }

    //[Required(ErrorMessage = "Last name is required")]
    [Display(Name = "Last name")]
    public string LastName { get; set; }

    public int NumberOfDays { get; set; } 

    public int AvailableNumberOfDays { get; set; }
    
    public DateTime? PasswordLastChanged { get; set; }
    
    public DateTime RegisterDate { get; set; } = DateTime.Now;
    
    public Guid UserLoginId { get; set; }
    
    public UserLogin UserLogin { get; set; }

}
