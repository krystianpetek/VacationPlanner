using System.Text.Json.Serialization;

namespace VacationPlannerAPI.Models;

public class TypeOfLeaveRequest
{
    public int Id { get; set; }
    public TypeOfLeave Type { get; set; }

    [JsonIgnore] public virtual DayOffRequest DayOffRequest { get; set; }

    public override string ToString()
    {
        return Type.ToString();
    }
}