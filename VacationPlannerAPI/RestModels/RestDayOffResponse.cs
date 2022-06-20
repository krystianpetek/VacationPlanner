using VacationPlannerAPI.Models;

namespace VacationPlannerAPI.RestModels
{
    public class RestDayOffResponse
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public string TypeOfLeave { get; set; }

        public DateTime DayOffRequestDate { get; set; }

        public DateTime RequestDate { get; set; }

        public string Status { get; set; }
    }
}
