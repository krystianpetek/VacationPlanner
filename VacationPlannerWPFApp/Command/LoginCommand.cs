using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using VacationPlannerWPFApp.Models;
using VacationPlannerWPFApp.Services;
using VacationPlannerWPFApp.Stores;
using VacationPlannerWPFApp.ViewModels;

namespace VacationPlannerWPFApp.Command.Login
{
    public class LoginCommand : AsyncCommandBase
    {
        private readonly LoginViewModel _viewModel;
        private readonly AccountStore _accountStore;
        private readonly AdminStore _adminStore;
        private readonly EmployeeStore _employeeStore;
        private readonly NavigationService<EmployeeViewModel> _navigationService;
        private readonly NavigationService<AdminViewModel> _adminNavigationService;

        public LoginCommand(LoginViewModel viewModel, AccountStore accountStore, NavigationService<EmployeeViewModel> navigationService, NavigationService<AdminViewModel> adminNavigationService, AdminStore adminStore, EmployeeStore employeeStore)
        {
            _employeeStore = employeeStore;
            _adminStore = adminStore;
            _viewModel = viewModel;
            _accountStore = accountStore;
            _navigationService = navigationService;
            _adminNavigationService = adminNavigationService;
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
                _navigationService.Navigate();
            }
        }

        private async Task<AdminModel> GetAdminInfo(Guid id)
        {
            var temporary = new AdminResponseModel();
            var json = new AdminModel();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("ApiKey", App.key);

                var response = await client.GetAsync($"https://localhost:7020/api/Company/user/{id}");
                var claimsResponse = await response.Content.ReadAsStringAsync();
                temporary = JsonConvert.DeserializeObject<AdminResponseModel>(claimsResponse);

                json = new AdminModel() { Id = id, CompanyName = temporary.CompanyName };
            }
            return json;
        }
        private async Task<EmployeeModel> GetEmployeeInfo(Guid id)
        {
            var temporary = new EmployeeResponseModel();
            var json = new EmployeeModel();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("ApiKey", App.key);

                var response = await client.GetAsync($"https://localhost:7020/api/Employee/user/{id}");
                var claimsResponse = await response.Content.ReadAsStringAsync();
                temporary = JsonConvert.DeserializeObject<EmployeeResponseModel>(claimsResponse);
                
                json = new EmployeeModel() {  Id = id, NumberOfDays = temporary.NumberOfDays, AvailableNumberOfDays = temporary.AvailableNumberOfDays, FirstName = temporary.FirstName, LastName = temporary.LastName };
            }
            return json;
        }

        private async Task<AccountModel> Login()
        {
            AccountModel json = new AccountModel();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("ApiKey", App.key);

                var data = new StringContent(JsonConvert.SerializeObject(new
                {
                    username = $"{_viewModel.Username}",
                    password = $"{_viewModel.Password}"
                }));

                data.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync("https://localhost:7020/api/user/login", data);
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

    
}
