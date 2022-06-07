using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationPlannerWPFApp.Models;

namespace VacationPlannerWPFApp.Stores
{
    public class AdminStore
    {
        private AdminModel _aboutAdmin;
        public AdminModel AboutAdmin
        {
            get => _aboutAdmin;
            set
            {
                _aboutAdmin = value;
            }
        }
    }
}
