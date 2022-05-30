using System.ComponentModel.DataAnnotations;
using VacationPlannerAPI.Models;

namespace VacationPlannerAPI.RestModels
{
    public class RestDayOffRequest
    {
        public TypeOfLeave TypeOfRequest { get; set; }

        public DateTime DayOffRequestDate { get; set; }

        public DateTime RequestDate { get; set; } = DateTime.Now;

        public Guid EmployeeId { get; set; }

        public Employee Employee { get; set; }
    }
}
