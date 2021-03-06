using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using VacationPlannerWPFApp.Models.Admin;
using VacationPlannerWPFApp.ViewModels.Admin;

namespace VacationPlannerWPFApp.Command.Admin;

public class AddEmployeeCommand : CommandBase
{
    private AdminAddEmployeeModel viewModel;
    private AdminAddEmployeeViewModel _vm;
    public AddEmployeeCommand(AdminAddEmployeeModel employeeModel, AdminAddEmployeeViewModel vm)
    {
        viewModel = employeeModel;
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
            string pass = viewModel.GeneratedPassword;
            var data = new StringContent(JsonConvert.SerializeObject(new
            {
                FirstName = $"{viewModel.FirstName}",
                LastName = $"{viewModel.LastName}",
                Username = $"{viewModel.UserName}",
                AvailableNumberOfDays = $"{viewModel.AvailableNumberOfDays}",
                NumberOfDays = $"{viewModel.NumberOfDays}",
                Password = $"{pass}"
            }));

            data.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = client.PostAsync($"https://{App.URLToAPI}/api/Employee/{viewModel.CompanyId}", data).Result;
            //viewModel.Info = response.Content.ReadAsStringAsync().Result;
            _vm.Message = response.Content.ReadAsStringAsync().Result;
            if (_vm.Message.Contains("created"))
            {
                _vm.SaveInfo = $"Save password for employee!";
                _vm.MessagePassword = pass;
            }
            else
            {
                _vm.SaveInfo = String.Empty;
                _vm.MessagePassword = String.Empty;
            }
        }
    }
}