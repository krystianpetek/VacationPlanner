using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationPlannerWPFApp.Models;

namespace VacationPlannerWPFApp.Stores
{
    public class HomeStore
    {
        private HomeModel _aboutUser;
        public HomeModel AboutUser
        {
            get => _aboutUser;
            set
            {
                _aboutUser = value;
            }
        }
    }
}
