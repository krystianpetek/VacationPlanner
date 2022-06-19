using VacationPlannerAPI.Models;

namespace VacationPlannerAPI.RestModels;

public class RestDayOffRequest
{
    public string TypeOfLeave { get; set; }

    public DateTime DayOffRequestDate { get; set; }

}