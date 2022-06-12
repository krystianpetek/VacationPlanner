﻿using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using VacationPlannerWPFApp.ViewModels;
using VacationPlannerWPFApp;

namespace VacationPlannerWPFApp.Command.Login
{
    public class RegisterCommand : AsyncCommandBase
    {
        private RegisterViewModel viewModel;

        public RegisterCommand(RegisterViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        protected override async Task ExecuteAsync(object? parameter)
        {
            await Register();
        }

        private async Task Register()
        {
            await Task.Run(async () =>
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("ApiKey", App.key);

                    var data = new StringContent(JsonConvert.SerializeObject(new
                    {
                        companyName = $"{viewModel.CompanyName}",
                        username = $"{viewModel.Username}",
                        password = $"{viewModel.Password}"
                    }));

                    data.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    var response = client.PostAsync($"https://{App.URLToAPI}/api/Company", data).Result;
                    viewModel.Info = await response.Content.ReadAsStringAsync();
                }
            });
        }
    }
}
