using System.ComponentModel.DataAnnotations;

namespace VacationPlannerAPI.RestModels;

public class RestEmployee
{
    [Required(ErrorMessage = "First name is required"),
           Display(Name = "First name"),
           MinLength(4),
           MaxLength(30),
           DataType(DataType.Text)]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required"),
           Display(Name = "Last name"),
           MinLength(4),
           MaxLength(50),
           DataType(DataType.Text)]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Number of days is required"),
            Display(Name = "Number of days"),
            MaxLength(2),
            DataType(DataType.Text)]
    public int NumberOfDays { get; set; }

    [Required(ErrorMessage = "Available number of days is required"),
            Display(Name = "Available number of days"),
            MaxLength(2),
            DataType(DataType.Text)]
    public int AvailableNumberOfDays { get; set; }

    [Required(ErrorMessage = "Username is required"),
            Display(Name = "Username"),
            MinLength(6),
            DataType(DataType.Text)]
    public string Username { get; set; }

    [Required(ErrorMessage = "Password is required"),
            Display(Name = "Password"),
            MinLength(8),
            DataType(DataType.Password)]
    public string Password { get; set; }
}
