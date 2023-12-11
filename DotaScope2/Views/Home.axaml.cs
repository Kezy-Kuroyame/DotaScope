using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace DotaScope2.Views
{
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
        }

        public void SteamLogIn(object source, RoutedEventArgs args)
        {
            Console.WriteLine("Click!");
        }

        public void toTeams(object source, RoutedEventArgs args)
        {
            Console.WriteLine("Переход в Teams");

        }
    }
}
