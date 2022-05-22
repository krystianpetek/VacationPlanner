using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VacationPlannerWPFApp.ViewModels;

namespace VacationPlannerWPFApp.Command
{
    public class LoginCommand : AsyncCommandBase
    {
        private LoginViewModel viewModel;

        public LoginCommand(LoginViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        protected override async Task ExecuteAsync(object? parameter)
        {
            await Login();
        }

        private async Task Login ()
        {
           await Task.Run(async () =>
           {
               using (HttpClient client = new HttpClient())
               {
                   client.DefaultRequestHeaders.Add("ApiKey", App.key);

                   var data = new StringContent(JsonConvert.SerializeObject(new
                   {
                       username = $"{viewModel.Login}",
                       password = $"{viewModel.Password}"
                   }));
                   data.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                   var response = client.PostAsync("https://localhost:7020/api/user/login", data).Result;

                   viewModel.Info = await response.Content.ReadAsStringAsync();
               }
           });
        }
    }
}
