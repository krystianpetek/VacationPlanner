using System.ComponentModel.DataAnnotations;

namespace VacationPlannerAPI.RestModels;

public class RestEmployeeRequest
{
    //[Required(ErrorMessage = "First name is required")]
    //[Display(Name = "First name")]
    //[MinLength(4)]
    //[MaxLength(30)]
    public string FirstName { get; set; }

    //[Required(ErrorMessage = "Last name is required")]
    //[Display(Name = "Last name")]
    //[MinLength(4)]
    //[MaxLength(50)]
    public string LastName { get; set; }

    //[Required(ErrorMessage = "Username is required")]
    //[Display(Name = "Username")]
    //[MinLength(4)]
    public string Username { get; set; }

    //[Required(ErrorMessage = "Available number of days is required")]
    //[Display(Name = "Available number of days")]
    public int AvailableNumberOfDays { get; set; }

    public int NumberOfDays { get; set; }

    public bool WorkMoreThan10Years { get; set; } = false;

    //[Required(ErrorMessage = "Password is required")]
    //[Display(Name = "Password")]
    //[MinLength(8)]
    //[DataType(DataType.Password)]0
    public string? Password { get; set; }
}