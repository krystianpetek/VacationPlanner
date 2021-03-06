using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using VacationPlannerWPFApp.Stores;
using VacationPlannerWPFApp.ViewModels.Employee;

namespace VacationPlannerWPFApp.Command.Employee
{
    public class AddRequestDayOffCommand : CommandBase
    {
        private AddRequestDayOffViewModel _viewModel;
        private EmployeeStore _employeeStore;
        private DayOffRequestsStore _dayOffRequestsStore;

        public AddRequestDayOffCommand(AddRequestDayOffViewModel vm, EmployeeStore employeeStore)
        {
            _viewModel = vm;
            _employeeStore = employeeStore;
        }

        public override void Execute(object? parameter)
        {
            AddRequest();
        }

        private void AddRequest()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("ApiKey", App.key);

                var data = new StringContent(JsonConvert.SerializeObject(new
                {
                    TypeOfLeave = $"{_viewModel.selectedType}",
                    DayOffRequestDate = _viewModel.DayOffRequestDate
                }));

                data.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = client.PostAsync($"https://{App.URLToAPI}/api/RequestDayOff/{_employeeStore.AboutEmployee.Id}", data).Result;
                _viewModel.Message = response.Content.ReadAsStringAsync().Result;
             }
        }
    }
}
