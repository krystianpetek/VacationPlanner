using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using VacationPlannerWPFApp.Models.HomeApp;

namespace VacationPlannerWPFApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public const string key = "mojSekretnyKluczAPI";
        //private ServiceProvider _serviceProvider;
        //public App()
        //{
        //    ServiceCollection services = new ServiceCollection();
        //    ConfigureServices(services);
        //    _serviceProvider = services.BuildServiceProvider();
        //}

        //private void ConfigureServices(ServiceCollection services)
        //{
        //    services.AddSingleton<ClaimsToWPF>();
        //}
    }

}
