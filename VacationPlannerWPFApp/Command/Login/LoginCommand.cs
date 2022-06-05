﻿using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using VacationPlannerWPFApp.Models.HomeApp;
using VacationPlannerWPFApp.Models.Login;
using VacationPlannerWPFApp.ViewModels;
using VacationPlannerWPFApp.ViewModels.Login;

namespace VacationPlannerWPFApp.Command.Login
{
    public class LoginCommand : AsyncCommandBase
    {
        private LoginViewModel viewModel;
        private MainScreen mainProgramWindow;
        public LoginCommand(LoginViewModel viewModel)
        {
            mainProgramWindow = new MainScreen();
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
                   var claimsResponse = await response.Content.ReadAsStringAsync();
                   var json = JsonConvert.DeserializeObject<ClaimsToWPF>(claimsResponse);
                   File.WriteAllText("save.txt", claimsResponse);
                   if(json.Message == "Logged in")
                   {
                       mainProgramWindow.Dispatcher.Invoke(() => mainProgramWindow.ShowDialog());
                   }
               }
           });
        }
    }
}