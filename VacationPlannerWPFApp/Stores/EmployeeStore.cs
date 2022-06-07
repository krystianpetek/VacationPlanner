using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationPlannerWPFApp.Models;

namespace VacationPlannerWPFApp.Stores
{
    public class EmployeeStore
    {
        private EmployeeModel _aboutEmployee;
        public EmployeeModel AboutEmployee
        {
            get => _aboutEmployee;
            set
            {
                _aboutEmployee = value;
            }
        }
    }
}
