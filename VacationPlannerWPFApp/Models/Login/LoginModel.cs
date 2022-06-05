using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationPlannerWPFApp.Models.Login
{
    public class LoginModel
    {
        public string? Login { get; set; }

        public string? Password { get; set; }

        public string? Info { get; set; } = string.Empty;
    }
}
