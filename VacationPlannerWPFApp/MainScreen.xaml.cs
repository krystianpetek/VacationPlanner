using System;
using System.ComponentModel;
using System.Windows;
using VacationPlannerWPFApp.Models.Login;
using VacationPlannerWPFApp.ViewModels.HomeApp;

namespace VacationPlannerWPFApp
{
    /// <summary>
    /// Interaction logic for TwoWindow.xaml
    /// </summary>
    public partial class MainScreen : Window
    {
        public ClaimsToWPF claims = new ClaimsToWPF() { Id = Guid.NewGuid(), Message = "Not logged", Role = null, Username = null };
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
