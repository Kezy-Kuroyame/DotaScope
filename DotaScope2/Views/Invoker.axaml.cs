using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using DotaScope2.ViewModels;
using System;

namespace DotaScope2.Views
{
    public partial class Invoker : UserControl
    {
        protected bool IsVertical()
        {
            Grid windowGrid = this.FindControl<Grid>("windowGrid");
            double boundsWidth = windowGrid.Bounds.Width;
            double boundsHeight = windowGrid.Bounds.Height;
            System.Diagnostics.Debug.WriteLine($"Ширина окна Invoker: {boundsWidth}, высота окна Invoker: {boundsHeight}");
            return (boundsHeight > boundsWidth);
        }

        private void InvokerWindow_Initialized(object sender, EventArgs e)
        {
            if (IsVertical())
            {
                ((InvokerViewModel)DataContext).IsMobile = true;
                Resize_Components();
            }
        }

        private void Resize_Components()
        {
            ResizeGridRows();
            ResizeGameColumn();
            ResizeButtons();
        }

        private void ResizeGridRows()
        {
            Grid windowGrid = this.FindControl<Grid>("windowGrid");
            windowGrid.MaxHeight = 3000; 

            Grid content = this.FindControl<Grid>("content");
            content.Margin = new Avalonia.Thickness(0, 150, 10, 0);

            RowDefinition newRowDefinition1 = new RowDefinition();
            content.RowDefinitions.Add(newRowDefinition1);
            RowDefinition newRowDefinition2 = new RowDefinition();
            content.RowDefinitions.Add(newRowDefinition2);
            RowDefinition newRowDefinition3 = new RowDefinition();
            content.RowDefinitions.Add(newRowDefinition3);

            Grid recordsColumnGrid = this.FindControl<Grid>("recordsColumnGrid");
            Grid gameColumnGrid = this.FindControl<Grid>("gameColumnGrid");
            Grid spellsColumnGrid = this.FindControl<Grid>("spellsColumnGrid");

            Grid.SetRow(gameColumnGrid, 0);
            Grid.SetRow(spellsColumnGrid, 1);
            Grid.SetRow(recordsColumnGrid, 2);

            content.ColumnDefinitions[0].Width = new GridLength();
            content.ColumnDefinitions[1].Width = new GridLength();
            content.ColumnDefinitions[2].Width = new GridLength();

            Grid.SetColumnSpan(gameColumnGrid, 3);
            Grid.SetColumnSpan(spellsColumnGrid, 3);
            Grid.SetColumnSpan(recordsColumnGrid, 3);

            content.RowDefinitions[0].Height = new GridLength(600);
            content.RowDefinitions[1].Height = new GridLength(600);
            content.RowDefinitions[2].Height = new GridLength(600);

        }

        private void ResizeGameColumn()
        {
            Grid gameColumnGrid = this.FindControl<Grid>("gameColumnGrid");
            gameColumnGrid.RowDefinitions[0].Height= new GridLength(200);
            gameColumnGrid.RowDefinitions[1].Height = new GridLength(300);
            gameColumnGrid.RowDefinitions[2].Height = new GridLength(100);



            Grid gameGridMain = this.FindControl<Grid>("gameGridMain");
            gameGridMain.ColumnDefinitions[1].Width = new GridLength(150, GridUnitType.Pixel);
            gameGridMain.ColumnDefinitions[2].Width = new GridLength(150, GridUnitType.Pixel);

            ((InvokerViewModel)DataContext).MarginValue = new Avalonia.Thickness(-15, 0, 0, 0);

        }

        private void ResizeButtons()
        {
            Grid pressedBallsGrid = this.FindControl<Grid>("pressedBallsGrid");

            pressedBallsGrid.ColumnDefinitions[1].Width = new GridLength(100, GridUnitType.Pixel);
            pressedBallsGrid.ColumnDefinitions[2].Width = new GridLength(100, GridUnitType.Pixel);
            pressedBallsGrid.ColumnDefinitions[3].Width = new GridLength(100, GridUnitType.Pixel);

            ((InvokerViewModel)DataContext).widthHeightBall = 75;

            ((InvokerViewModel)DataContext).ballButton = 75;

            ((InvokerViewModel)DataContext).ballButtonText = 20;

        }

        public Invoker()
        {
            InitializeComponent();
            this.Loaded += InvokerWindow_Initialized;
        }

        private void QButtonClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Q Event");
            ((InvokerViewModel)DataContext).addBallToCache("Q");
            // Обработать событие нажатия на кнопку здесь
        }
        private void WButtonClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("W Event");
            ((InvokerViewModel)DataContext).addBallToCache("W");

            // Обработать событие нажатия на кнопку здесь
        }
        private void EButtonClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("E Event");
            ((InvokerViewModel)DataContext).addBallToCache("E");
            // Обработать событие нажатия на кнопку здесь
        }
        private void RButtonClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("R Event");
            ((InvokerViewModel)DataContext).castSpell();
            // Обработать событие нажатия на кнопку здесь
        }

        private void ButtonKeyUp(object sender, KeyEventArgs e)
        {
            // Проверить, является ли клавиша Enter
            if (e.Key == Key.Q)
            {
                // Активировать код для клавиши Enter
                QButtonClick(sender, e);
            }
            if (e.Key == Key.W)
            {
                // Активировать код для клавиши Enter
                WButtonClick(sender, e);
            }
            if (e.Key == Key.E)
            {
                // Активировать код для клавиши Enter
                EButtonClick(sender, e);
            }
            if (e.Key == Key.R)
            {
                // Активировать код для клавиши Enter
                RButtonClick(sender, e);
            }
        }

        private void StartGameClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Start Game event");
            ((InvokerViewModel)DataContext).startGame();
            // Обработать событие нажатия на кнопку здесь
        }

        private void Binding(object? sender, Avalonia.Input.KeyEventArgs e)
        {
        }
    }
}
