using Avalonia.Controls;
using Avalonia.Interactivity;
using DotaScope2.ViewModels;

namespace DotaScope2.Views
{
    public partial class LogIn : UserControl
    {
        public LogIn()
        {
            InitializeComponent();
            DataContext = new LogInViewModel();
        }

        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Login Button Click");
            ((LogInViewModel)DataContext).LoginFunc();
        }
    }
}
