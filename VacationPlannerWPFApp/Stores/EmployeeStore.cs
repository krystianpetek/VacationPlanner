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
