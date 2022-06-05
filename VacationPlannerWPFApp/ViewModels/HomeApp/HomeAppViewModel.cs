using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VacationPlannerWPFApp.Command.HomeApp;
using VacationPlannerWPFApp.Models.HomeApp;

namespace VacationPlannerWPFApp.ViewModels.HomeApp
{
    internal class HomeAppViewModel : BaseViewModels
    {
        public HomeAppViewModel()
        {
        }
        public string Emp { get; set; }
        
    }
}
