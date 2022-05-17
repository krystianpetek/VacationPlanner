using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationPlannerWPFApp.ViewModels
{
    public class MainViewModels : BaseViewModels
    {
        private BaseViewModels _selectedViewModel;
        public  BaseViewModels SelectedViewModel
        {
            get
            {
                return _selectedViewModel;
            }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }
    }
}
