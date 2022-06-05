using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationPlannerWPFApp.Models.Login
{
    public class RegisterModel
    {
        public string? CompanyName { get; set; }

        public string? Username { get; set; }

        public string? Password { get; set; }

        public string? Info { get; set; } = string.Empty;
    }
}
