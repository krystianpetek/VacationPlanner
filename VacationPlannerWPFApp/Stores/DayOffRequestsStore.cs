using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationPlannerWPFApp.Models;

namespace VacationPlannerWPFApp.Stores
{
    public class DayOffRequestsStore
    {
        public IEnumerable<DayOffRequest> dayOffRequests { get; set; }
    }
}
