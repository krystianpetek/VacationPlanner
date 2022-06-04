using VacationPlannerAPI.Models;

namespace VacationPlannerAPI.RestModels
{
    public class RestCompanyRequest
    {
        public string? CompanyName { get; set; }

        public string? Username { get; set; }

        public string? Password { get; set; }
    }
}
