using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationPlannerWPFApp.Models.Employee
{
    public class ShowAllRequestsModel
    {
        public DateTime DayOffRequestDate { get; set; }

        public DateTime RequestDate { get; set; }

        public string TypeOfLeave { get; set; } 

        public Status Status { get; set; }

    }
}
