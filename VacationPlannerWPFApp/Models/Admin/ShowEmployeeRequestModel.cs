using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationPlannerWPFApp.Models.Admin
{
    public class ShowEmployeeRequestModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string DayOffRequestDate { get; set; }
        public string TypeOfLeave { get; set; }
        public string Status { get; set; }
    }
}
