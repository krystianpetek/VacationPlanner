using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Windows;

namespace VacationPlannerWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string UserName = "";
        public MainWindow()
        {
            InitializeComponent();
        }
        private const string key = "mojSekretnyKluczAPI";
        //private string bearer = "";
        private async void baton_Click(object sender, RoutedEventArgs e)
        {
            
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("ApiKey", key);
                
                var data = new StringContent(JsonConvert.SerializeObject(new
                {
                    username = $"{loginTb.Text}",
                    password = $"{hasloTb.Text}"
                }));
                data.Headers.ContentType = new MediaTypeHeaderValue("application/json"); // <-
                var response = client.PostAsync("https://localhost:7020/api/user/login", data).Result;

                UserName = loginTb.Text;
                
                //List<Claim> claims = new List<Claim>() {
                //    new Claim(ClaimTypes.Name, loginTb.Text),
                //    new Claim(ClaimTypes.Role, "")
                //};

                sprawdzLoginLbl.Content = await response.Content.ReadAsStringAsync();
                
            }
        }
    }
}
