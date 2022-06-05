using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Input;
using VacationPlannerWPFApp.Command.HomeApp;
using VacationPlannerWPFApp.Models.HomeApp;

namespace VacationPlannerWPFApp.ViewModels.HomeApp
{
    public class MainScreenViewModels : BaseViewModels
    {
        private BaseViewModels _selectedViewModel;
        public BaseViewModels SelectedViewModel
        {
            get
            {
                return _selectedViewModel;
            }
            set
            {
                try
                {
                    var file = File.ReadAllText("save.txt");
                    claims = JsonConvert.DeserializeObject<ClaimsToWPF>(file);
                    if (claims.Role.ToString() == "Administrator")
                        _selectedViewModel = new AdministratorViewModel();
                    else
                        _selectedViewModel = new HomeAppViewModel();

                }
                catch (Exception ex)
                { }
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }
        public ICommand UpdateViewCommand { get; set; }

        public MainScreenViewModels()
        {
            UpdateViewCommand = new HomeAppViewCommand(this);
            
        }
    }
}
