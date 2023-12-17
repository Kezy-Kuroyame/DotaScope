using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using DotaScope2.ViewModels;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DotaScope2.Views
{
    public partial class Teams : UserControl
    {
        private readonly TeamsViewModel _viewModel;
        public Teams()
        {
            InitializeComponent();
            System.Diagnostics.Debug.WriteLine("��� � ��� ���������");
            _viewModel = new TeamsViewModel();
            DataContext = _viewModel;
            
            Loaded += async (sender, e) => await LoadData();
        }

        private async Task LoadData()
        {
            // �������� ������ �� ������� ��� �������
            System.Diagnostics.Debug.WriteLine("��������� ������ �� �������");
            await _viewModel.GetDataFromServer();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public void SteamLogIn(object source, RoutedEventArgs args)
        {
            Console.WriteLine("Click!");
        }

        public void toTeams(object source, RoutedEventArgs args)
        {
            Console.WriteLine("������� � Teams");
        }

       
    }
}
