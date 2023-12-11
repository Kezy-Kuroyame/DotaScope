using Avalonia.Controls;
using Avalonia.Interactivity;
using DotaScope2.ViewModels;
using System;
using System.Net.Http;

namespace DotaScope2.Views
{
    public partial class Teams : UserControl
    {
        public Teams()
        {
            InitializeComponent();
            System.Diagnostics.Debug.WriteLine("Бля а так выводится");
            DataContext = new TeamsViewModel();
            LoadData();
            
        }
        public void SteamLogIn(object source, RoutedEventArgs args)
        {
            Console.WriteLine("Click!");
        }

        public void toTeams(object source, RoutedEventArgs args)
        {
            Console.WriteLine("Переход в Teams");
        }

        private async void LoadData()
        {
            // Загрузка данных из сервера при запуске
            await ((TeamsViewModel)DataContext).GetDataFromServer();
        }
    }
}
