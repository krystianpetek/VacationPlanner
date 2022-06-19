using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using VacationPlannerWPFApp.Models;
using VacationPlannerWPFApp.Stores;
using VacationPlannerWPFApp.ViewModels.NavigationBars;

namespace VacationPlannerWPFApp.ViewModels.Admin
{
    public class ShowEmployeesViewModel : ViewModelBase
    {
        private readonly AdminStore _adminStore;
        private readonly EmployeeStore _employeeStore;

        public List<EmployeeModel> employees { get; set; }

        public AdminNavigationBarViewModel NavigationBarViewModel { get; }

        public ShowEmployeesViewModel(AdminNavigationBarViewModel navigationBar, AdminStore adminStore)
        {
            _adminStore = adminStore;
            NavigationBarViewModel = navigationBar;
            employees = GetEmployeesByCompanyId(_adminStore.AboutAdmin.CompanyId);
        }

        private static List<EmployeeModel> GetEmployeesByCompanyId(Guid companyId)
        {
            List<EmployeeModel> collection = new List<EmployeeModel>();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("ApiKey", App.key);

                var response = client.GetAsync($"https://{App.URLToAPI}/api/Employee/ByCompany/{companyId}").Result;
                if (response.StatusCode == HttpStatusCode.NotFound)
                    return new List<EmployeeModel>();
                var claimsResponse = response.Content.ReadAsStringAsync().Result;
                collection = JsonConvert.DeserializeObject<List<EmployeeModel>>(claimsResponse);
            }
            return collection;
        }

        public string CompanyName
        {
            get => _adminStore.AboutAdmin.CompanyName;
        }
    }
}
