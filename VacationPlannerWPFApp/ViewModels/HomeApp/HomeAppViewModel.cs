using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationPlannerWPFApp.Models.HomeApp;

namespace VacationPlannerWPFApp.ViewModels.HomeApp
{
    public class HomeAppViewModel :  BaseViewModels
    {
        private HomeModel homeModel;

        public HomeAppViewModel()
        {
            homeModel = new HomeModel();
        }

        public string Role
        {
            get => homeModel.Role;
            set
            {
                homeModel.Role = value;
                OnPropertyChanged(nameof(Role));

            }
        }
    }
}
