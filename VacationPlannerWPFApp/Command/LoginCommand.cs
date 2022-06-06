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
        private readonly NavigationService<EmployeeViewModel> _navigationService;
        private readonly NavigationService<AdminViewModel> _adminNavigationService;

        public LoginCommand(LoginViewModel viewModel, AccountStore accountStore, NavigationService<EmployeeViewModel> navigationService, NavigationService<AdminViewModel> adminNavigationService)
        {
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
                _adminNavigationService.Navigate();
            else
                _navigationService.Navigate();
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
                var response = client.PostAsync("https://localhost:7020/api/user/login", data).Result;
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
