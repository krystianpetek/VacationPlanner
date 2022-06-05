using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;
using VacationPlannerWPFApp.Models.HomeApp;
using VacationPlannerWPFApp.Services;
using VacationPlannerWPFApp.Stores;
using VacationPlannerWPFApp.ViewModels;

namespace VacationPlannerWPFApp.Command.Login
{
    public class LoginCommand : CommandBase
    {
        private readonly LoginViewModel _viewModel;
        private readonly AccountStore _accountStore;
        private readonly NavigationService<AccountViewModel> _navigationService;

        public LoginCommand(LoginViewModel viewModel, AccountStore accountStore, NavigationService<AccountViewModel> navigationService)
        {
            _viewModel = viewModel;
            _accountStore = accountStore;
            _navigationService = navigationService;
        }

        public override void Execute(object? parameter)
        {
            MessageBox.Show($"Logging in {_viewModel.Username}");
            var account = Login().Result;
            _accountStore.CurrentAccount = account;
            _navigationService.Navigate();
        }

        private async Task<AccountModel> Login ()
        {
               AccountModel json;
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
                   json = JsonConvert.DeserializeObject<AccountModel>(claimsResponse);
               }
               return json;
           
        }
    }
}
