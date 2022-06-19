using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationPlannerWPFApp.Models.Employee
{
    public class AddRequestDayOffModel
    {

        public string TypeOfLeave { get; set; }

        public DateTime DayOffRequestDate { get; set; }

    }
}
