using Avalonia.Controls;
using DotaScope2.ViewModels;

namespace DotaScope2.Views;

public partial class MainWindow : Window
{
    private ViewModelBase _contentViewModel;
    private UserControl _contentView;
    private HomeViewModel _mainViewModel;

    public MainWindow()
    {
        InitializeComponent();
 
    }
    private void ShowFirstView()
    {
    }
}
