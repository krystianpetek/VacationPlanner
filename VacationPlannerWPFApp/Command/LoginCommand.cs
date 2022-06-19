using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VacationPlannerWPFApp.Models;
using VacationPlannerWPFApp.Services;
using VacationPlannerWPFApp.Stores;
using VacationPlannerWPFApp.ViewModels;

namespace VacationPlannerWPFApp.Command.Login;

public class LoginCommand : AsyncCommandBase
{
    private readonly AccountStore _accountStore;
    private readonly NavigationService<AdminViewModel> _adminNavigationService;
    private readonly AdminStore _adminStore;
    private readonly DayOffRequestsStore _dayOffRequestsStore;
    private readonly EmployeeStore _employeeStore;
    private readonly NavigationService<EmployeeViewModel> _navigationService;
    private readonly LoginViewModel _viewModel;

    public LoginCommand(LoginViewModel viewModel, AccountStore accountStore,
        NavigationService<EmployeeViewModel> navigationService,
        NavigationService<AdminViewModel> adminNavigationService, AdminStore adminStore, EmployeeStore employeeStore,
        DayOffRequestsStore dayOffRequestsStore)
    {
        _viewModel = viewModel;
        _accountStore = accountStore;
        _navigationService = navigationService;
        _adminNavigationService = adminNavigationService;
        _adminStore = adminStore;
        _employeeStore = employeeStore;
        _dayOffRequestsStore = dayOffRequestsStore;
    }

    protected override async Task ExecuteAsync(object? parameter)
    {
        AccountModel account = null;
        try
        {
            account = await Login();
            if (account.Role is null)
            {
                _viewModel.Info = account.Message;
                return;
            }
        }
        catch (Exception ex)
        {
        }

        _accountStore.CurrentAccount = account;
        if (_accountStore.CurrentAccount.Role == "Administrator")
        {
            _adminStore.AboutAdmin = await GetAdminInfo(account.Id);
            _adminNavigationService.Navigate();
        }
        else
        {
            _employeeStore.AboutEmployee = await GetEmployeeInfo(account.Id);
            _dayOffRequestsStore.dayOffRequests = await GetDayOffRequestsById(account.Id);
            _navigationService.Navigate();
        }
    }

    private async Task<IEnumerable<DayOffRequest>> GetDayOffRequestsById(Guid id)
    {
        IEnumerable<DayOffRequest> collection = new List<DayOffRequest>();

        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("ApiKey", App.key);

            var response = await client.GetAsync($"https://{App.URLToAPI}/api/RequestDayOff/{id}");
            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;
            var claimsResponse = await response.Content.ReadAsStringAsync();
            collection = JsonConvert.DeserializeObject<IEnumerable<DayOffRequest>>(claimsResponse);
        }

        return collection;
    }

    private async Task<AdminModel> GetAdminInfo(Guid id)
    {
        var temporary = new AdminResponseModel();
        var json = new AdminModel();
        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("ApiKey", App.key);

            var response = await client.GetAsync($"https://{App.URLToAPI}/api/Company/ByAdmin/{id}");
            var claimsResponse = await response.Content.ReadAsStringAsync();
            temporary = JsonConvert.DeserializeObject<AdminResponseModel>(claimsResponse);

            json = new AdminModel { Id = id, CompanyName = temporary.CompanyName, CompanyId = temporary.CompanyId };
        }

        return json;
    }

    private async Task<EmployeeModel> GetEmployeeInfo(Guid id)
    {
        var temporary = new EmployeeResponseModel();
        var json = new EmployeeModel();
        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("ApiKey", App.key);

            var response = await client.GetAsync($"https://{App.URLToAPI}/api/Employee/ByUser/{id}");
            var claimsResponse = await response.Content.ReadAsStringAsync();
            temporary = JsonConvert.DeserializeObject<EmployeeResponseModel>(claimsResponse);

            json = new EmployeeModel
            {
                Id = id, NumberOfDays = temporary.NumberOfDays, AvailableNumberOfDays = temporary.AvailableNumberOfDays,
                FirstName = temporary.FirstName, LastName = temporary.LastName
            };
        }

        return json;
    }

    private async Task<AccountModel> Login()
    {
        var json = new AccountModel();
        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("ApiKey", App.key);

            var data = new StringContent(JsonConvert.SerializeObject(new
            {
                username = $"{_viewModel.Username}",
                password = $"{_viewModel.Password}"
            }));

            data.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync($"https://{App.URLToAPI}/api/user/login", data);
            var claimsResponse = await response.Content.ReadAsStringAsync();
            try
            {
                json = JsonConvert.DeserializeObject<AccountModel>(claimsResponse);
            }
            catch (Exception ex)
            {
                json.Message = claimsResponse;
            }
        }

        return json;
    }
}