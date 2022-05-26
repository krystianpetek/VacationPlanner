using System.ComponentModel.DataAnnotations;
using VacationPlannerAPI.Models;

namespace VacationPlannerAPI.RestModels
{
    public class RestDayOffRequest
    {
        public TypeOfLeave TypeOfRequest { get; set; }

        public DateTime DayOffRequest { get; set; }

        public DateTime RequestTime { get; set; } = DateTime.Now;

        public RestEmployee Employee { get; set; }
    }
}
