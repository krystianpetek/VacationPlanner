using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using VacationPlannerWPFApp.ViewModels.Login;

namespace VacationPlannerWPFApp.Command
{
    public class LoginCommand : AsyncCommandBase
    {
        private LoginViewModel viewModel;
        private MainWindow mainProgramWindow;

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

                   if(viewModel.Info == "Logged in")
                   {
                       mainProgramWindow.Dispatcher.Invoke(() => mainProgramWindow.ShowDialog());
                       await Task.Delay(2000);
                   }
                   
               }
           });
        }
    }
}
