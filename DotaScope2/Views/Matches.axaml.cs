using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.LogicalTree;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;
using DotaScope2.ViewModels;
using System;
using System.Net.Http;

namespace DotaScope2.Views
{
    public partial class Matches: UserControl
    {
        public string playerID;
        protected bool IsVertical()
        {
            Grid mainWindow = this.FindControl<Grid>("mainWindow");
            var boundsWidth = mainWindow.Bounds.Width;
            var boundsHeight = mainWindow.Bounds.Height;
            System.Diagnostics.Debug.WriteLine($"Ширина окна Matches: {boundsWidth}, высота окна Matches: {boundsHeight}");
            return boundsHeight >= boundsWidth;
        }
        public Matches()
        {
            InitializeComponent();
            Loaded += ResizeComponents;
            DataContext = new MatchesViewModel();
            LoadData();

        }
        private async void LoadData()
        {
            // Загрузка данных из сервера при запуске
            await ((MatchesViewModel)DataContext).GetDataFromServer();
        }

        private void ResizeComponents(object sender, EventArgs e)
        {
            if (IsVertical())
            {
                ItemsControl AndroidName = this.FindControl<ItemsControl>("AndroidName");
                AndroidName.IsVisible = true;

                Grid MatchesHeaderGridAndroid = this.FindControl<Grid>("MatchesHeaderGridAndroid");
                MatchesHeaderGridAndroid.IsVisible = true;
          

                TextBlock textBlock = this.FindControl<TextBlock>("MatchesText");
                textBlock.IsVisible = false;

                Grid topBackground = this.FindControl<Grid>("TopBackground");
                topBackground.RowDefinitions[0].Height = new GridLength(360);

                Grid rank = this.FindControl<Grid>("GridRank");
                rank.Margin = new Avalonia.Thickness(0, 20, 0, 20);
                rank.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center;
                Grid.SetRow(rank, 1);

                Grid matchesHeaderGrid = this.FindControl<Grid>("MatchesHeaderGrid");
                matchesHeaderGrid.IsVisible = false;
                Grid.SetRow(matchesHeaderGrid, 2);


                Grid avatar = this.FindControl<Grid>("GridAvatar");
                avatar.Margin = new Avalonia.Thickness(150, 20, 0, 0);
                Grid.SetRow(avatar, 0);


                //playerName.Margin = new Avalonia.Thickness(150, 0, 0, 200);

                //Grid matchesGrid = this.FindControl<Grid>("MatchesGrid");
                //ItemsControl matchesHeaderGrid = this.FindControl<ItemsControl>("MatchesHeaderGrid");

            }
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
          
        }
    }
}
