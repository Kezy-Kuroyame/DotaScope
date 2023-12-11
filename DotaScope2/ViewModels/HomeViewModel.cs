using DotaScope2.Views;
using ReactiveUI;

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

    private object _contentViewModel;

    public HomeViewModel() {
        
    }
    public object ContentViewModel
    {
        get => _contentViewModel;
        set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
    }

    public void toTeams()
    {
        ContentViewModel = new TeamsViewModel();
    }
}
