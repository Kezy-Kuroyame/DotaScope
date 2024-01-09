using Avalonia.Controls;
using DotaScope2.Models;
using DotaScope2.Views;
using DynamicData;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Windows.Input;


namespace DotaScope2.ViewModels;

public class MainViewModel : NavigationViewModel
{
    public string Greeting => "Welcome to Avalonia!";
    public string Block => "MainViewModel";
    public string DotaScope => "DotaScope";
    public string Matches => "Matches";
    public string Teams => "Teams";
    private string _logIn = "Login In";
    public string LogIn
    {
        get => _logIn;
        set {
            this.RaiseAndSetIfChanged(ref _logIn, value);
        }
    }

    private int _id = -1;
    public int UserId { get { return _id; } set { _id = value; } }

    public void SetUserId(int userId)
    {
        UserId = userId;
    }


    public string Invoker => "Invoker";

    static readonly NavigationViewModel[] Pages =
    {
        new HomeViewModel(),
        new TeamsViewModel(),
        new MatchesViewModel(),
    };

    private NavigationViewModel _CurrentPage = new HomeViewModel();

    public NavigationViewModel CurrentPage
    {
        get { return _CurrentPage; }
        private set
        {
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
            System.Diagnostics.Debug.WriteLine(UserId);
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
            System.Diagnostics.Debug.WriteLine("Main User Id: " + UserId);
            CurrentPage = new InvokerViewModel(UserId);
    }

    public ICommand NavigateLogInSignUpCommand { get; }
        private void NavigateLogInSignUp()
        {
            CurrentPage = new LogInSignUpViewModel(this);
        }

}


