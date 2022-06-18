using VacationPlannerAPI.Models;

namespace VacationPlannerAPI.RestModels
{
    public class RestDayOffResponse
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public string TypeOfLeave { get; set; }

        public string DayOffRequestDate { get; set; }

        public string Status { get; set; }
    }
}
