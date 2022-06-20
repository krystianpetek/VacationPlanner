using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VacationPlannerWPFApp.Command.Employee;
using VacationPlannerWPFApp.Stores;
using VacationPlannerWPFApp.ViewModels.NavigationBars;

namespace VacationPlannerWPFApp.ViewModels.Employee
{
    public class AddRequestDayOffViewModel : ViewModelBase
    {
        public List<string> typeOfLeave { get; }

        public EmployeeNavigationBarViewModel NavigationBarViewModel { get; set; }

        private readonly EmployeeStore _employeeStore;

        private readonly DayOffRequestsStore _dayOffRequestsStore;

        public AddRequestDayOffViewModel(EmployeeNavigationBarViewModel navigationBar, EmployeeStore employeeStore, DayOffRequestsStore dayOffRequestsStore)
        {
            NavigationBarViewModel = navigationBar;
            _employeeStore = employeeStore;
            _dayOffRequestsStore = dayOffRequestsStore;
            typeOfLeave = initialTypeOfLeaveList();
            selectedType = typeOfLeave[0];
            AddDayOffRequestCommand = new AddRequestDayOffCommand(this, _employeeStore);
        }

        public ICommand AddDayOffRequestCommand { get; }

        public string Message { get; set; }

        public string selectedType { get; set; }

        public DateTime DayOffRequestDate { get; set; } = DateTime.Now;

        private List<string>? initialTypeOfLeaveList()
        {
            List<string> collection = new List<string>();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("ApiKey", App.key);

                var response = client.GetAsync($"https://{App.URLToAPI}/api/RequestDayOff/typeOfLeave").Result;
                if (response.StatusCode == HttpStatusCode.NotFound)
                    return null;
                var claimsResponse = response.Content.ReadAsStringAsync().Result;
                collection = JsonConvert.DeserializeObject<List<string>>(claimsResponse);
            }

            return collection;

        }

    }
}
