using Avalonia.Controls;
using Avalonia.Interactivity;
using DotaScope2.ViewModels;
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
            // Создайте новый экземпляр ViewModel и View
            var newViewModel = new TeamsViewModel();
            var newView = new Teams { DataContext = newViewModel };

            // Установите новый контент в основное окно
            var HomeViewModel = (HomeViewModel)DataContext;
            HomeViewModel.ContentViewModel = newView;
        }
    }
}
