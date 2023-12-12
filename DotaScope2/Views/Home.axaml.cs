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
            Console.WriteLine("������� � Teams");
            // �������� ����� ��������� ViewModel � View
            var newViewModel = new TeamsViewModel();
            var newView = new Teams { DataContext = newViewModel };

            // ���������� ����� ������� � �������� ����
            var HomeViewModel = (HomeViewModel)DataContext;
            HomeViewModel.ContentViewModel = newView;
        }
    }
}
