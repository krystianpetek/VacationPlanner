using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using VacationPlannerWPFApp.Command.Admin;
using VacationPlannerWPFApp.Models.Admin;
using System.Linq;
using VacationPlannerWPFApp.Stores;
using VacationPlannerWPFApp.ViewModels.NavigationBars;
using VacationPlannerWPFApp.Command;

namespace VacationPlannerWPFApp.ViewModels.Admin;

public class ShowEmployeeRequestsViewModel : ViewModelBase
{
    private readonly AdminStore _adminStore;
    public AdminNavigationBarViewModel NavigationBarViewModel { get; }
    public ObservableCollection<ShowEmployeeRequestModel> showEmployeeRequests { get; set; }
    public ObservableCollection<string> leaveType { get; set; }

    //public ICommand ShowEmployeeRequestsCommand { get; }

    public ICommand Nav { get; set; }

    public ShowEmployeeRequestsViewModel(AdminNavigationBarViewModel navigationBar, AdminStore adminStore)
    {
        NavigationBarViewModel = navigationBar;
        showEmployeeRequests = new ObservableCollection<ShowEmployeeRequestModel>(GetDayOffRequestsById(adminStore.AboutAdmin.CompanyId));
        leaveType = new ObservableCollection<string>() { "Pending", "Rejected", "Accepted" };
        Nav = new NavCommand(showEmployeeRequests);
        //ShowEmployeeRequestsCommand = new ShowEmployeeRequestsCommand(this);
    }

    private static IEnumerable<ShowEmployeeRequestModel> GetDayOffRequestsById(Guid id)
    {
        IEnumerable<ShowEmployeeRequestModel> collection = new List<ShowEmployeeRequestModel>();

        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("ApiKey", App.key);

            var response = client.GetAsync($"https://{App.URLToAPI}/api/RequestDayOff/{id}/company").Result;
            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;
            var claimsResponse = response.Content.ReadAsStringAsync().Result;
            collection = JsonConvert.DeserializeObject<IEnumerable<ShowEmployeeRequestModel>>(claimsResponse);
        }
        return collection;
    }

    public class NavCommand : CommandBase
    {
        private ObservableCollection<ShowEmployeeRequestModel> showEmployeeRequests;
        public NavCommand(ObservableCollection<ShowEmployeeRequestModel> emp)
        {
            showEmployeeRequests = emp;
        }
        public override void Execute(object? parameter)
        {

        }
    }
}