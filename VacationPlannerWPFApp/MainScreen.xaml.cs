using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using VacationPlannerWPFApp.Models.Login;
using VacationPlannerWPFApp.ViewModels;
using VacationPlannerWPFApp.ViewModels.HomeApp;

namespace VacationPlannerWPFApp
{
    /// <summary>
    /// Interaction logic for TwoWindow.xaml
    /// </summary>
    public partial class MainScreen : Window
    {
        public MainScreen()
        {
            InitializeComponent();
            DataContext = new MainScreenViewModels();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }

    }
}
