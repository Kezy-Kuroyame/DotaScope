using Avalonia.Media;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DotaScope2.ViewModels
{
    internal class LogInSignUpViewModel : NavigationViewModel
    {
        private readonly NavigationViewModel[] Pages =
         {
         };

        private double _textSizeButton = 50;

        public double buttonFontSize
        {
            get => _textSizeButton;
            set
            {
                this.RaiseAndSetIfChanged(ref _textSizeButton, value);
            }
        }

        

        private NavigationViewModel _RegistrationPage;

        public NavigationViewModel RegistrationPage
        {
            get { return _RegistrationPage; }
            private set { this.RaiseAndSetIfChanged(ref _RegistrationPage, value); }
        }

        private MainViewModel _MainViewModel;
        public MainViewModel MainViewModel { get { return _MainViewModel; }  set { _MainViewModel = value; } }

        public LogInSignUpViewModel(MainViewModel mainViewModel)
        {
            RegistrationPage = new LogInViewModel(mainViewModel);

            // Create Observables which will activate to deactivate our commands based on CurrentPage 

            NavigateLogInCommand = ReactiveCommand.Create(NavigateLogIn);
            NavigateSignUpCommand = ReactiveCommand.Create(NavigateSignUp);
            MainViewModel = mainViewModel;
        }

        private IBrush _textColorLogIn = new SolidColorBrush(Color.FromRgb(179, 97, 243));
        public IBrush TextColorLogIn
        {
            get => _textColorLogIn;
            set => this.RaiseAndSetIfChanged(ref _textColorLogIn, value);
        }

        private IBrush _textColorSignUp = new SolidColorBrush(Colors.White);
        public IBrush TextColorSignUp
        {
            get => _textColorSignUp;
            set => this.RaiseAndSetIfChanged(ref _textColorSignUp, value);
        }

        private TextDecorationCollection _textDecorationsLogIn = new TextDecorationCollection
        {
            new TextDecoration
            {
                Location = TextDecorationLocation.Underline,
            }
        };
        public TextDecorationCollection TextDecorationsLogIn
        {
            get => _textDecorationsLogIn;
            set => this.RaiseAndSetIfChanged(ref _textDecorationsLogIn, value);
        }

        private TextDecorationCollection _textDecorationSignUp = null;
        public TextDecorationCollection TextDecorationsSignUp
        {
            get => _textDecorationSignUp;
            set => this.RaiseAndSetIfChanged(ref _textDecorationSignUp, value);
        }

        public ICommand NavigateLogInCommand { get; }
        private void NavigateLogIn()
        {
            TextColorSignUp = new SolidColorBrush(Colors.White);
            TextColorLogIn = new SolidColorBrush(Color.FromRgb(179, 97, 243));

            TextDecorationsSignUp = null;
            TextDecorationsLogIn = new TextDecorationCollection
            {
                new TextDecoration
                {
                    Location = TextDecorationLocation.Underline
                }
            };

            RegistrationPage = new LogInViewModel(MainViewModel);
        }

        public ICommand NavigateSignUpCommand { get; }
        private void NavigateSignUp()
        {
            TextColorSignUp = new SolidColorBrush(Color.FromRgb(179, 97, 243)); 
            TextColorLogIn = new SolidColorBrush(Colors.White);

            TextDecorationsSignUp = new TextDecorationCollection
            {
                new TextDecoration
                {
                    Location = TextDecorationLocation.Underline
                }
            };
            TextDecorationsLogIn = null;

            RegistrationPage = new SignUpViewModel(MainViewModel);
        }
    }
}
