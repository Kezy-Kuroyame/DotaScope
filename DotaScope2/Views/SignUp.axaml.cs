using Avalonia.Controls;
using Avalonia.Interactivity;
using DotaScope2.ViewModels;

namespace DotaScope2.Views
{
    public partial class SignUp : UserControl
    {
        public SignUp()
        {
            InitializeComponent();
            DataContext = new SignUpViewModel();
        }

        private void SignUpButtonClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("SignUp Button Click");
            ((SignUpViewModel)DataContext).SignUpFunc();
        }
    }
}
