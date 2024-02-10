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

        protected bool IsVertical()
        {
            Grid windowGrid = this.FindControl<Grid>("windowGrid");
            double boundsWidth = windowGrid.Bounds.Width;
            double boundsHeight = windowGrid.Bounds.Height;
            System.Diagnostics.Debug.WriteLine($"Ширина окна Teams: {boundsWidth}, высота окна Teams: {boundsHeight}");
            return (boundsHeight > boundsWidth);
        }

        private void TeamWindow_Initialized(object sender, EventArgs e)
        {
            if (IsVertical())
            {
                Resize_Components();
            }
        }

        private void resizeTeamTextBlock()
        {
            TextBlock teamsTextBlock = this.FindControl<TextBlock>("teamsTextBlock");
            teamsTextBlock.Margin = new Avalonia.Thickness(0);
            teamsTextBlock.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center;
        }

        private void resizeTable()
        {
            DataGrid dataGrid = this.FindControl<DataGrid>("dataGrid");
            dataGrid.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Left;
            dataGrid.Width = 350;

            Grid gridContent = this.FindControl<Grid>("gridContent");
            gridContent.Margin = new Avalonia.Thickness(20, 0);

            _viewModel.dataFontSize = 24;

        }

        private void Resize_Components()
        {
            resizeTeamTextBlock();
            resizeTable();
        }

        public Teams()
        {
            InitializeComponent();

            this.Loaded += TeamWindow_Initialized;


            _viewModel = new TeamsViewModel();
            DataContext = _viewModel;
            
            Loaded += async (sender, e) => await LoadData();
        }

        private async Task LoadData()
        {
            // Загрузка данных из сервера при запуске
            System.Diagnostics.Debug.WriteLine("Загружаем данные из сервера");
            await _viewModel.GetDataFromServer();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

      

       
    }
}
