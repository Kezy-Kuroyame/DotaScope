using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;

namespace DotaScope2.Views
{
    public partial class Invoker : UserControl
    {
        public Invoker()
        {
            InitializeComponent();
        }

        private void QButtonClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Q Event");

            // Обработать событие нажатия на кнопку здесь
        }
        private void WButtonClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("W Event");

            // Обработать событие нажатия на кнопку здесь
        }
        private void EButtonClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("E Event");

            // Обработать событие нажатия на кнопку здесь
        }
        private void RButtonClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("R Event");
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
    }
}
