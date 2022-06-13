using System.ComponentModel.DataAnnotations;

namespace VacationPlannerAPI.RestModels;

public class RestEmployeeRequest
{
    [Required(ErrorMessage = "First name is required")]
    [Display(Name = "First name")]
    [MinLength(4)]
    [MaxLength(30)]
    [DataType(DataType.Text)]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    [Display(Name = "Last name")]
    [MinLength(4)]
    [MaxLength(50)]
    [DataType(DataType.Text)]
    public string? LastName { get; set; }

    public bool WorkMoreThan10Year { get; set; }

    [Required(ErrorMessage = "Available number of days is required")]
    [Display(Name = "Available number of days")]
    public int AvailableNumberOfDays { get; set; }

    [Required(ErrorMessage = "Username is required")]
    [Display(Name = "Username")]
    [MinLength(4)]
    [DataType(DataType.Text)]
    public string? Username { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [Display(Name = "Password")]
    [MinLength(8)]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
}