using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.LogicalTree;
using Avalonia.Markup.Xaml;
using DotaScope2.ViewModels;
using System;
using System.Net.Http;

namespace DotaScope2.Views
{
    public partial class Matches: UserControl
    {
        public string playerID;
        private bool isVertical = false;
        protected bool IsVertical()
        {
            var boundsWidth = this.Bounds.Width;
            var boundsHeight = this.Bounds.Height;
            return boundsHeight >= boundsWidth;
        }
        public Matches()
        {
            isVertical = IsVertical();
            InitializeComponent();
            DataContext = new MatchesViewModel();
            LoadData();

        }
        private async void LoadData()
        {
            // Загрузка данных из сервера при запуске
            await ((MatchesViewModel)DataContext).GetDataFromServer();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            if (isVertical == true)
            {
                TextBlock textBlock = this.FindControl<TextBlock>("MatchesText");
                textBlock.IsVisible = false;

                Grid topBackground = this.FindControl<Grid>("TopBackground");
                topBackground.RowDefinitions[0].Height = new GridLength(360);

                Grid rank = this.FindControl<Grid>("GridRank");
                rank.Margin = new Avalonia.Thickness(0, 20, 0, 20);
                rank.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center;
                Grid.SetRow(rank, 1);

                Grid matchesHeaderGrid = this.FindControl<Grid>("MatchesHeaderGrid");
                Grid.SetRow(matchesHeaderGrid, 2);


                Grid avatar = this.FindControl<Grid>("GridAvatar");
                avatar.Margin = new Avalonia.Thickness(150, 20, 0, 0);
                Grid.SetRow(avatar, 0);

                Grid playerName = this.FindControl<Grid>("PlayerName");
                //playerName.Margin = new Avalonia.Thickness(150, 0, 0, 200);

                //Grid matchesGrid = this.FindControl<Grid>("MatchesGrid");
                //ItemsControl matchesHeaderGrid = this.FindControl<ItemsControl>("MatchesHeaderGrid");

            }
        }
    }
}
