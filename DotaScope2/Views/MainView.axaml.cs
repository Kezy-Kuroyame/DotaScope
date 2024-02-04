using Avalonia.Controls;
using DynamicData;
using System;

namespace DotaScope2.Views;

public partial class MainView : UserControl
{
    protected bool IsVertical()
    {
        Grid gridWindow = this.FindControl<Grid>("gridWindow");
        double boundsWidth = gridWindow.Bounds.Width;
        double boundsHeight = gridWindow.Bounds.Height;
        System.Diagnostics.Debug.WriteLine($"Ширина окна: {boundsWidth}, высота окна: {boundsHeight}");
        return (boundsHeight > boundsWidth);
    }

    public MainView()
    {
        InitializeComponent();
        this.Loaded += MainWindow_Initialized;
    }

    private void Resize_Header()
    {
        HideButtons();
        ReColumnGridHeader();
        CreateNativeMenu();
    }

    private void CreateNativeMenu()
    {
        NativeMenu nativeMenu = new NativeMenu();
        NativeMenuItem home = new NativeMenuItem("Home");
        NativeMenuItem teams = new NativeMenuItem("Teams");
        NativeMenuItem matches = new NativeMenuItem("Matches");
        NativeMenuItem invoker = new NativeMenuItem("Invoker");

        nativeMenu.Add(home);
        nativeMenu.Add(teams);
        nativeMenu.Add(matches);
        nativeMenu.Add(invoker);

        AddNativeMenu(nativeMenu);
        Grid gridHeader = this.FindControl<Grid>("gridHeader");
        Grid.SetRow(nativeMenu, 0);

        gridHeader.Children.Add((nativeMenu);
    }

    private void HideButtons()
    {
        Button homeButton = this.FindControl<Button>("homeButton");
        Button teamsButton = this.FindControl<Button>("teamsButton");
        Button matchesButton = this.FindControl<Button>("matchesButton");
        Button invokerButton = this.FindControl<Button>("invokerButton");
        Grid gridButtons = this.FindControl<Grid>("gridButtons");

        gridButtons.IsVisible = false;

        homeButton.IsVisible = false;
        teamsButton.IsVisible = false;
        matchesButton.IsVisible = false;
        invokerButton.IsVisible = false;

    }

    private void ReColumnGridHeader()
    {
        Grid gridHeader = this.FindControl<Grid>("gridHeader");
        ColumnDefinition column2 = gridHeader.ColumnDefinitions[1];
        column2.Width = new GridLength(0, GridUnitType.Pixel);
    }

    private void AddNativeMenu(NativeMenu nativeMenu)
    {
        


    }

    private void MainWindow_Initialized(object sender, EventArgs e)
    {
        if (IsVertical())
        {
            Resize_Header();
        }
    }
}
