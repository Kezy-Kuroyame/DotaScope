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

        Button navigateLogInSignUpButton = this.FindControl<Button>("navigateLogInSignUpButton");
        navigateLogInSignUpButton.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center;

        Menu menu = this.FindControl<Menu>("menu");
        menu.IsVisible = true;
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

        ColumnDefinition column1 = gridHeader.ColumnDefinitions[0];
        column1.Width = new GridLength(250, GridUnitType.Pixel);

        ColumnDefinition column2 = gridHeader.ColumnDefinitions[1];
        column2.Width = new GridLength(0, GridUnitType.Pixel);

        ColumnDefinition column4 = gridHeader.ColumnDefinitions[3];
        column4.Width = new GridLength(150, GridUnitType.Pixel);

    }

   

    private void MainWindow_Initialized(object sender, EventArgs e)
    {
        if (IsVertical())
        {
            Resize_Header();
        }
    }
}
