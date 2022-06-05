using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationPlannerWPFApp.Models.HomeApp;
using VacationPlannerWPFApp.Models.Login;

namespace VacationPlannerWPFApp.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        public ClaimsToWPF claims = new ClaimsToWPF() { Id = Guid.NewGuid(),Message = "Not logged", Role = null, Username = null};
        public event PropertyChangedEventHandler? PropertyChanged;

        public virtual void Dispose() { }

        protected void OnPropertyChanged(string propertyName)
        {
             PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));
        }
    }
}
