using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;

namespace DotaScope2.Views
{
    public partial class Home : UserControl
    {
        protected bool IsVertical()
        {
            Grid windowGrid = this.FindControl<Grid>("windowGrid");
            double boundsWidth = windowGrid.Bounds.Width;
            double boundsHeight = windowGrid.Bounds.Height;
            System.Diagnostics.Debug.WriteLine($"Ширина окна: {boundsWidth}, высота окна: {boundsHeight}");
            return (boundsHeight > boundsWidth);
        }


        public Home()
        {

            this.InitializeComponent();
            this.Loaded += MainWindow_Initialized;

        }
        private void InitializeComponent()
        {
            // Загрузка XAML-разметки
            AvaloniaXamlLoader.Load(this);

        }

        private void Resize_Components()
        {
            resizeHeader();

            Image scope = this.FindControl<Image>("scope");
            TextBlock textInImage = this.FindControl<TextBlock>("TextInImage");
            Grid infoPart = this.FindControl<Grid>("infoPart");
            TextBlock question = this.FindControl<TextBlock>("question");
            TextBlock info = this.FindControl<TextBlock>("info");
            TextBlock headerInfo = this.FindControl<TextBlock>("headerInfo");
            Grid infoBlock = this.FindControl<Grid>("infoBlock");

            // Добавление обработчика события Click
            scope.Width = 350;
            scope.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center;
            scope.Margin = new Avalonia.Thickness(35, 0, 0, 0);

            textInImage.FontSize = textInImage.FontSize / 2;
            textInImage.Width = 370 / 2;
            textInImage.Margin = new Avalonia.Thickness(0, 85, 0, 0);

            RowDefinition newRowDefinition1 = new RowDefinition();
            infoPart.RowDefinitions.Add(newRowDefinition1);
            RowDefinition newRowDefinition2 = new RowDefinition();
            infoPart.RowDefinitions.Add(newRowDefinition2);
            Grid.SetRow(question, 0);
            Grid.SetRow(infoBlock, 1);
            Grid.SetColumn(question, 0);
            Grid.SetColumn(infoBlock, 0);

            infoPart.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center;
            infoBlock.Width = 300;
            question.Margin = new Avalonia.Thickness(0, 0, 15, 0);

            question.FontSize = question.FontSize / 2 + 8;
            info.FontSize = info.FontSize / 2 + 8;
            info.LineHeight /= 2;
            headerInfo.FontSize = headerInfo.FontSize / 2 + 8;

            infoBlock.Margin = new Avalonia.Thickness(0, -50, 0, 0);
        }
        
        private void resizeHeader()
        {

        }

        private void MainWindow_Initialized(object sender, EventArgs e)
        {
            if (IsVertical()) { 
                Resize_Components();

            }

        }



    }
}
