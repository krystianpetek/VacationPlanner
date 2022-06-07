using System;

namespace VacationPlannerWPFApp.Models
{
    public class DayOffRequest
    {
        public Guid Id { get; set; }

        public DateTime DayOffRequestDate { get; set; }

        public Status Status { get; set; }

        public string TypeOfLeave { get; set; }
    }
}
