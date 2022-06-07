using System.ComponentModel.DataAnnotations;

namespace VacationPlannerAPI.Models
{
    public class DayOffRequest
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime DayOffRequestDate { get; set; }

        public DateTime RequestDate { get; set; } = DateTime.Now;

        public Status Status { get; set; }

        
        public Guid EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }

        public int TypeOfLeaveId { get; set; }
        public virtual TypeOfLeaveRequest TypeOfLeave { get; set; }

    }
}
