using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using DotaScope2.ViewModels;

namespace DotaScope2.Views
{
    public partial class Invoker : UserControl
    {
        public Invoker()
        {
            InitializeComponent();
            DataContext = new InvokerViewModel();
        }

        private void QButtonClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Q Event");
            ((InvokerViewModel)DataContext).addBallToCache("Q");
            // ���������� ������� ������� �� ������ �����
        }
        private void WButtonClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("W Event");
            ((InvokerViewModel)DataContext).addBallToCache("W");

            // ���������� ������� ������� �� ������ �����
        }
        private void EButtonClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("E Event");
            ((InvokerViewModel)DataContext).addBallToCache("E");
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
