using Avalonia.Controls;
using Avalonia.Controls.Utils;
using Avalonia.Interactivity;
using DotaScope2.ViewModels;
using System;

namespace DotaScope2.Views
{
    public partial class LogIn : UserControl
    {
        public LogIn()
        {
            InitializeComponent();
            this.Loaded += LogInWindow_Initialized;

        }
      

        protected bool IsVertical()
        {
            Grid windowGrid = this.FindControl<Grid>("windowGrid");
            double boundsWidth = windowGrid.Bounds.Width;
            double boundsHeight = windowGrid.Bounds.Height;
            System.Diagnostics.Debug.WriteLine($"Ўирина окна LogInSignUp: {boundsWidth}, высота окна Teams: {boundsHeight}");
            return (boundsHeight > boundsWidth);
        }

        private void Resize_Components()
        {
            ((LogInViewModel)DataContext).buttonFontHeader = 35;
            ((LogInViewModel)DataContext).FieldFontSize = 20;
            ((LogInViewModel)DataContext).FieldWidth = 300;

            TextBox NameLoginField = this.FindControl<TextBox>("NameLoginField");
            TextBox PasswordLoginField = this.FindControl<TextBox>("PasswordLoginField");

            NameLoginField.Padding = new Avalonia.Thickness(20, 20, 0, 0);
            PasswordLoginField.Padding = new Avalonia.Thickness(20, 20, 0, 0);

            PasswordLoginField.VerticalAlignment = Avalonia.Layout.VerticalAlignment.Top;
            PasswordLoginField.Margin = new Avalonia.Thickness(0, 5, 0, 0);
        }

        private void LogInWindow_Initialized(object sender, EventArgs e)
        {
            if (IsVertical())
            {
                Resize_Components();
            }
        }
    }
}
