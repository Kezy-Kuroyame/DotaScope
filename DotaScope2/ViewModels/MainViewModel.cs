using Avalonia.Controls;
using DotaScope2.Models;
using DotaScope2.Views;
using DynamicData;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Windows.Input;


namespace DotaScope2.ViewModels;

public class MainViewModel : ViewModelBase
{
    public string Greeting => "Welcome to Avalonia!";
    public string Block => "MainViewModel";
    public string DotaScope => "DotaScope";
    public string Matches => "Matches";
    public string Teams => "Teams";
    public string LogIn => "Login In";
    public string Invoker => "Invoker";



    private readonly ViewModelBase[] Pages =
    {
        new HomeViewModel(),
        new TeamsViewModel(),
        new MatchesViewModel(),
        new InvokerViewModel(),
        new LogInSignUpViewModel()
    };

    private ViewModelBase _CurrentPage;

    public ViewModelBase CurrentPage
    {
        get  {   return _CurrentPage;    }
        private set {
            this.RaiseAndSetIfChanged(ref _CurrentPage, value); 
            System.Diagnostics.Debug.WriteLine("изменение CurrentPage");
            System.Diagnostics.Debug.WriteLine(_CurrentPage);
        }
    }
  

    public MainViewModel()
    {
        _CurrentPage = Pages[0];

        // Create Observables which will activate to deactivate our commands based on CurrentPage 

        NavigateHomeCommand = ReactiveCommand.Create(NavigateHome);
        NavigateTeamsCommand = ReactiveCommand.Create(NavigateTeams);
        NavigateMatchesCommand = ReactiveCommand.Create(NavigateMatches);
        NavigateInvokerCommand = ReactiveCommand.Create(NavigateInvoker);
        NavigateLogInSignUpCommand = ReactiveCommand.Create(NavigateLogInSignUp);
    }

    public ICommand NavigateHomeCommand { get; }
    public void NavigateHome()
    {
        System.Diagnostics.Debug.WriteLine("Переход домой");
        CurrentPage = Pages[0];
    }

    public ICommand NavigateTeamsCommand { get; }
    private void NavigateTeams()
    {
        System.Diagnostics.Debug.WriteLine("Нажатие в команды");
        CurrentPage = Pages[1];
    }

    public ICommand NavigateMatchesCommand { get; }
    private void NavigateMatches()
    {
        CurrentPage = Pages[2];
    }
    
    public ICommand NavigateInvokerCommand { get; }
    private void NavigateInvoker()
    {
        CurrentPage = Pages[3];
    }

    public ICommand NavigateLogInSignUpCommand { get; }
    private void NavigateLogInSignUp()
    {
        CurrentPage = Pages[4];
    }


}


