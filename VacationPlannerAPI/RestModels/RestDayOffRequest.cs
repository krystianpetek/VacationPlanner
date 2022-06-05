using VacationPlannerAPI.Models;

namespace VacationPlannerAPI.RestModels
{
    public class RestDayOffRequest
    {
        public TypeOfLeave TypeOfRequest { get; set; }

        public DateTime DayOffRequestDate { get; set; }

    }
}
