using Avalonia.Controls;
using DotaScope2.Views;
using ReactiveUI;
using System.Reactive;

namespace DotaScope2.ViewModels;

public class HomeViewModel: ViewModelBase
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

    public HomeViewModel()
        
    {
        NavigateToTeamsViewCommand = ReactiveCommand.Create(() =>
        {
            NavigateToTeams();
        });
    }
    public void NavigateToTeams()
    {
        // Переключаемся на SecondView при вызове этого метода
        var teamsViewModel = new TeamsViewModel();

        // Создаем экземпляр FirstView и связываем его с FirstViewModel
        var teamsView = new Teams
        {
            DataContext = teamsViewModel
        };

        // По умолчанию отображаем FirstView
        ContentView = teamsView;
    }

}
