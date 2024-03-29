﻿using Avalonia.Controls;
using DotaScope2.Views;
using ReactiveUI;
using System.Reactive;

namespace DotaScope2.ViewModels;

public class HomeViewModel: NavigationViewModel
{
    public string DotaScope => "DotaScope";
    public string Matches => "Matches";
    public string Teams => "Teams";
    public string LogIn => "Login In";
    public string DotaScopeSpace => "Dota\nScope";
    public string WhatIsHeader => "Что такое DotaScope?";
    public string WhatIsText => "Это сервис для просмотра статистики в игре Dota 2. Вы можете посмотреть информацию о конкретном матче, список своих матчей, матчи других игроков. \r\nТакже вы можете посмотреть статистику професcиональных команд";
    public string Block => "HomeViewModel";
    private UserControl _contentView;
    
    private double widthImageScope = 700;
    public double WidthImageScope
    {
        get { return widthImageScope; }

        set => this.RaiseAndSetIfChanged(ref widthImageScope, value);
    }

    public UserControl ContentView
    {
        get
        {
            System.Diagnostics.Debug.WriteLine("обращается в ContentView");
            if (_contentView == null) { _contentView = new Home(); }
            return _contentView;
        }
        private set => this.RaiseAndSetIfChanged(ref _contentView, value);
    }

    public ReactiveCommand<Unit, Unit> NavigateToTeamsViewCommand { get; }

    public void reSize()
    {
        WidthImageScope = 300;
    }

    public HomeViewModel() {    

    }

}
