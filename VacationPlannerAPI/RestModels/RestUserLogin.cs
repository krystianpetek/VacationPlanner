using System.ComponentModel.DataAnnotations;

namespace VacationPlannerAPI.RestModels
{
    public class RestUserLogin
    {
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
}
