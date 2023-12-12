using Avalonia.Controls;
using Avalonia.Interactivity;
using DotaScope2.ViewModels;
using System;
using System.Net.Http;

namespace DotaScope2.Views
{
    public partial class Matches: UserControl
    {
        public string playerID;
        public Matches()
        {
            InitializeComponent();
            DataContext = new MatchesViewModel();
            LoadData();

        }
        public void toTeams(object source, RoutedEventArgs args)
        {
            Console.WriteLine("Переход в Teams");
        }
        private async void LoadData()
        {
            // Загрузка данных из сервера при запуске
            await ((MatchesViewModel)DataContext).GetDataFromServer();
        }
    }
}
