﻿namespace VacationPlannerAPI.Models
{
    public class DayOffRequest
    {

        public Guid Id { get; set; }
        
        public TypeOfLeave TypeOfRequest { get; set; }

        public DateTime DayOffRequestDate { get; set; }

        public DateTime RequestDate { get; set; } = DateTime.Now;

        public Guid EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
