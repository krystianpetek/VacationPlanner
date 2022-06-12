using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationPlannerWPFApp.Models
{
    public class AdminAddEmployeeModel
    {
        [Required]
        public Guid CompanyId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string GeneratePassword { get; set; }
        public bool WorkMoreThan10Years { get; set; }
        public int AvailableNumberOfDays { get; set; }
        public int NumberOfDays { get; set; } = 20;

    }
}
