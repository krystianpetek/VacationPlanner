using System.Collections.Generic;
using VacationPlannerWPFApp.Models;

namespace VacationPlannerWPFApp.Stores
{
    public class DayOffRequestsStore
    {
        public IEnumerable<DayOffRequest> dayOffRequests { get; set; }
    }
}
