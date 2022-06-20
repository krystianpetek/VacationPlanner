using System.ComponentModel;

namespace VacationPlannerWPFApp.ViewModels;

/// <summary>
/// Base view for application, all views inherits from this
/// </summary>
public class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}