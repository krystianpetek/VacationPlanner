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
using System.Net.Http.Headers;
using System.Windows.Data;

namespace VacationPlannerWPFApp.ViewModels.Admin;

public class ShowEmployeeRequestsViewModel : ViewModelBase
{
    public AdminNavigationBarViewModel NavigationBarViewModel { get; }
    public ObservableCollection<ShowEmployeeRequestModel> showEmployeeRequests { get; set; }
    public ObservableCollection<string> leaveType { get; set; }

    private ShowEmployeeRequestModel _selectedModel { get; set; } = new ShowEmployeeRequestModel();
    public ShowEmployeeRequestModel SelectedModel
    {
        get => _selectedModel;
        set
        {
            _selectedModel = value;
            OnPropertyChanged(nameof(SelectedModel));
            OnPropertyChanged(nameof(ID));
            OnPropertyChanged(nameof(Statusik));
        }
    }
    public string ID
    {
        get => SelectedModel.Id.ToString();
        set
        { 
            SelectedModel.Id= Guid.Parse(value);
        }
    }
    public string Statusik
    {
        get => SelectedModel.Status;
        set
        {
            SelectedModel.Status = value;
            Register(Guid.Parse(ID));
            showEmployeeRequests.FirstOrDefault(x => x.Id == _selectedModel.Id).Status = _selectedModel.Status;
            CollectionViewSource.GetDefaultView(showEmployeeRequests).Refresh();
        }
    }

    public ShowEmployeeRequestsViewModel(AdminNavigationBarViewModel navigationBar, AdminStore adminStore)
    {
        NavigationBarViewModel = navigationBar;
        var result = GetDayOffRequestsById(adminStore.AboutAdmin.CompanyId).ToList();
        showEmployeeRequests = new ObservableCollection<ShowEmployeeRequestModel>(result);
        leaveType = new ObservableCollection<string>() { "Accepted", "Pending", "Rejected" };
    }

    private static IEnumerable<ShowEmployeeRequestModel> GetDayOffRequestsById(Guid id)
    {
        IEnumerable<ShowEmployeeRequestModel> collection = new List<ShowEmployeeRequestModel>();

        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("ApiKey", App.key);

            var response = client.GetAsync($"https://{App.URLToAPI}/api/RequestDayOff/{id}/company").Result;
            if (response.StatusCode == HttpStatusCode.NotFound)
                return new ObservableCollection<ShowEmployeeRequestModel>();
            var claimsResponse = response.Content.ReadAsStringAsync().Result;
            collection = JsonConvert.DeserializeObject<IEnumerable<ShowEmployeeRequestModel>>(claimsResponse);
        }
        return collection;
    }

    private void Register(Guid Id)
    {
        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("ApiKey", App.key);
            var data = new StringContent(JsonConvert.SerializeObject(new
            {
                Status = _selectedModel.Status
            }));

            data.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = client.PutAsync($"https://{App.URLToAPI}/api/RequestDayOff/{Id}", data).Result;
            var result = response.Content.ReadAsStringAsync().Result;
        }
    }
    public enum Status
    {
        Pending,
        Accepted,
        Rejected
    }
}