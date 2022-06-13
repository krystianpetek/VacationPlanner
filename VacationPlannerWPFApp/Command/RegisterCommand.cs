using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VacationPlannerWPFApp.ViewModels;

namespace VacationPlannerWPFApp.Command.Login;

public class RegisterCommand : CommandBase
{
    private readonly RegisterViewModel viewModel;

    public RegisterCommand(RegisterViewModel viewModel)
    {
        this.viewModel = viewModel;
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

            var data = new StringContent(JsonConvert.SerializeObject(new
            {
                companyName = $"{viewModel.CompanyName}",
                username = $"{viewModel.Username}",
                password = $"{viewModel.Password}"
            }));

            data.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = client.PostAsync($"https://{App.URLToAPI}/api/Company", data).Result;
            viewModel.Info = response.Content.ReadAsStringAsync().Result;
        }
    }
}