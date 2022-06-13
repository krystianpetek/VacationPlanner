using System.ComponentModel.DataAnnotations;

namespace VacationPlannerAPI.RestModels;

public class RestPasswordChange
{
    [Required(ErrorMessage = "Old password is required")]
    [Display(Name = "Old password")]
    [MinLength(8)]
    [DataType(DataType.Password)]
    public string? OldPassword { get; set; }

    [Required(ErrorMessage = "New password is required")]
    [Display(Name = "New password")]
    [MinLength(8)]
    [DataType(DataType.Password)]
    public string? NewPassword { get; set; }

    [Required(ErrorMessage = "Repeat password is required")]
    [Display(Name = "Repeat password")]
    [MinLength(8)]
    [DataType(DataType.Password)]
    public string? RepeatPassword { get; set; }
}