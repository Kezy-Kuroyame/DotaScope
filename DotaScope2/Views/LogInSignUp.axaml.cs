using Avalonia.Controls;
using DotaScope2.ViewModels;
using System;

namespace DotaScope2.Views
{
    public partial class LogInSignUp : UserControl
    {

        public LogInSignUp()
        {
            InitializeComponent();
            this.Loaded += LogInSignUpWindow_Initialized;

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
            ((LogInSignUpViewModel)DataContext).buttonFontSize = 25;
        }

        private void LogInSignUpWindow_Initialized(object sender, EventArgs e)
        {
            if (IsVertical())
            {
                Resize_Components();
            }
        }
    }
}
