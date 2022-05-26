using System.ComponentModel.DataAnnotations;

namespace VacationPlannerAPI.RestModels
{
    public class RestUserLogin
    {
        [Required(ErrorMessage = "Username is required"), 
            Display(Name = "Username"), 
            MinLength(6)]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required"), 
            Display(Name = "Password"), 
            MinLength(8)]
        public string Password { get; set; } = string.Empty;

    }
}
