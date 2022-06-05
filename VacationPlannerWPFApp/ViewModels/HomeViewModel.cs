﻿using System.Windows.Input;
using VacationPlannerWPFApp.Command;
using VacationPlannerWPFApp.Services;
using VacationPlannerWPFApp.Stores;

namespace VacationPlannerWPFApp.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public ICommand NavigateCommand { get; }

        public HomeViewModel(AccountStore accountStore, NavigationStore navigationStore)
        {
            NavigateCommand = new NavigateCommand<LoginViewModel>(
                new NavigationService<LoginViewModel>(navigationStore, 
                () => new LoginViewModel(accountStore, navigationStore)));
        }
    }
}
