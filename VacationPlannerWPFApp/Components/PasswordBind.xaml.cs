using System.Windows;
using System.Windows.Controls;

namespace VacationPlannerWPFApp.Components
{
    /// <summary>
    /// Interaction logic for PasswordBind.xaml
    /// </summary>
    public partial class PasswordBind : UserControl
    {
        public PasswordBind()
        {
            InitializeComponent();
        }

        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(PasswordBind), new PropertyMetadata(string.Empty));



        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Password = PasswordBox.Password;
        }
    }
}
