using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationPlannerWPFApp.Models.Employee
{
    public class AddRequestDayOffModel
    {
        public Guid Id { get; set; }

        public DateTime DayOffRequestDate { get; set; }

        public TypeOfLeave Type { get; set; }

        public Guid EmployeeId { get; set; }

        public DateTime RequestDate { get; set; } = DateTime.Now;
    }
}
