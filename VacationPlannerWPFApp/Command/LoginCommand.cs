﻿using Newtonsoft.Json;
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
    public class LoginCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private LoginViewModel viewModel;

        public bool CanExecute(object? parameter)
        {
            return true;
        }
        public LoginCommand(LoginViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public async void Execute(object? parameter)
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
        }
    }
}
