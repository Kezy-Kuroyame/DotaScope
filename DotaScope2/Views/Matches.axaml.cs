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

 //       private void InitializeComponent()
 //       {
 //           AvaloniaXamlLoader.Load(this);
 //           if (isVertical == true)
 //           {
 //                TextBlock textBlock = this.FindControl<TextBlock>("MatchesText");

                // Удаление всех дочерних элементов из Grid
 //               textBlock.IsVisible = false;
                // Добавление Grid в окно
//                Content = textBlock;
//            }
//        }
    }
}
