using VacationPlannerAPI.Models;

namespace VacationPlannerAPI.RestModels;

public class RestDayOffRequest
{
    public Guid Id { get; set; }

    public TypeOfLeaveRequest TypeOfLeave { get; set; }

    public DateTime DayOffRequestDate { get; set; }

    public Status Status { get; set; }

    public Guid CompanyId { get; set; }
}