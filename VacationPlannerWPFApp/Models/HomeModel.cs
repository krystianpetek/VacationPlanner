using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationPlannerWPFApp.Models
{
    public class HomeModel
    {
        public Guid Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int NumberOfDays { get; set; }

        public int AvailableNumberOfDays { get; set; }
    }
}
