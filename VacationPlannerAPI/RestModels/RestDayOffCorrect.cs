using VacationPlannerAPI.Models;

namespace VacationPlannerAPI.RestModels;

public class RestDayOffCorrect
{
    public Guid Id { get; set; }

    public TypeOfLeaveRequest TypeOfLeave { get; set; }

    public DateTime DayOffRequestDate { get; set; }
}