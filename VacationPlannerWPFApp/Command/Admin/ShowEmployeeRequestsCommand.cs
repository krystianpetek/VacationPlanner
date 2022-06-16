using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using VacationPlannerWPFApp.Models.Admin;
using VacationPlannerWPFApp.ViewModels.Admin;

namespace VacationPlannerWPFApp.Command.Admin;
 /// <summary>
 /// ??????????????????
 /// </summary>
internal class ShowEmployeeRequestsCommand : CommandBase
{
    private ShowEmployeeRequestModel _employeeRequests;
    private ShowEmployeeRequestsViewModel _vm;
    public ShowEmployeeRequestsCommand(ShowEmployeeRequestModel employeeRequests, ShowEmployeeRequestsViewModel vm)
    {
        _employeeRequests = employeeRequests;
        _vm = vm;
    }
    public override void Execute(object? parameter)
     {
        Register();
    }

    private void Register()
    {
        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("ApiKey", App.key);
            var data = new StringContent(JsonConvert.SerializeObject(new
            {
                Id = $"{_employeeRequests.Id}",
                FullName = $"{_employeeRequests.FullName}",
                DayOffRequestDate = $"{_employeeRequests.DayOffRequestDate}",
                TypeOfLeave = $"{_employeeRequests.TypeOfLeave}",
                Status = $"{_employeeRequests.Status}"
            }));

            data.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = client.PutAsync($"https://{App.URLToAPI}/api/RequestDayOff/", data).Result;
            var result = response.Content.ReadAsStringAsync().Result;
        }
    }
}