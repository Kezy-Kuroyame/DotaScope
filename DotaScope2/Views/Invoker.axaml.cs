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

            // ���������� ������� ������� �� ������ �����
        }
        private void WButtonClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("W Event");

            // ���������� ������� ������� �� ������ �����
        }
        private void EButtonClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("E Event");

            // ���������� ������� ������� �� ������ �����
        }
        private void RButtonClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("R Event");
            // ���������� ������� ������� �� ������ �����
        }

        private void ButtonKeyUp(object sender, KeyEventArgs e)
        {
            // ���������, �������� �� ������� Enter
            if (e.Key == Key.Q)
            {
                // ������������ ��� ��� ������� Enter
                QButtonClick(sender, e);
            }
            if (e.Key == Key.W)
            {
                // ������������ ��� ��� ������� Enter
                WButtonClick(sender, e);
            }
            if (e.Key == Key.E)
            {
                // ������������ ��� ��� ������� Enter
                EButtonClick(sender, e);
            }
            if (e.Key == Key.R)
            {
                // ������������ ��� ��� ������� Enter
                RButtonClick(sender, e);
            }
        }
    }
}
