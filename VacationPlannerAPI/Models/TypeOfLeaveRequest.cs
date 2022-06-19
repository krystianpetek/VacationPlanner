using System.Text.Json.Serialization;

namespace VacationPlannerAPI.Models;

public class TypeOfLeaveRequest
{
    public int Id { get; set; }
    public string TypeOfLeave { get; set; }
}