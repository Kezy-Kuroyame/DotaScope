using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using DotaScope2.ViewModels;
using System;
using System.Drawing;

namespace DotaScope2.Views
{
    public partial class SignUp : UserControl
    {
        public SignUp()
        {
            InitializeComponent();
            this.Loaded += SignUpWindow_Initialized;

        }


        protected bool IsVertical()
        {
            Grid windowGrid = this.FindControl<Grid>("windowGrid");
            double boundsWidth = windowGrid.Bounds.Width;
            double boundsHeight = windowGrid.Bounds.Height;
            System.Diagnostics.Debug.WriteLine($"Ўирина окна SignUp: {boundsWidth}, высота окна SignUp: {boundsHeight}");
            return (boundsHeight > boundsWidth);
        }

        private void Resize_Components()
        {
            ((SignUpViewModel)DataContext).buttonFontHeader = 35;
            ((SignUpViewModel)DataContext).FieldFontSize = 20;
            ((SignUpViewModel)DataContext).FieldWidth = 300;

            TextBox NameLoginField = this.FindControl<TextBox>("NameLoginField");
            TextBox PasswordLoginField = this.FindControl<TextBox>("PasswordLoginField");

            NameLoginField.Padding = new Avalonia.Thickness(20, 20, 0, 0);
            PasswordLoginField.Padding = new Avalonia.Thickness(20, 20, 0, 0);

            PasswordLoginField.VerticalAlignment = Avalonia.Layout.VerticalAlignment.Top;
            PasswordLoginField.Margin = new Avalonia.Thickness(0, 5, 0, 0);

            
        }

        private void SignUpWindow_Initialized(object sender, EventArgs e)
        {
            if (IsVertical())
            {
                Resize_Components();
            }
        }
        
    }
}
