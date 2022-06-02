using System.ComponentModel.DataAnnotations;

namespace VacationPlannerAPI.RestModels
{
    public class RestUserLogin
    {
        public string Username { get; set; }

        public string Password { get; set; }

    }
}
