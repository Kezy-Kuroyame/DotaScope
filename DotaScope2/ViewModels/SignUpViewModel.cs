using DotaScope2.Models;
using DotaScope2.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;


namespace DotaScope2.ViewModels
{
    public class SignUpViewModel : NavigationViewModel
    {
        private User _user;
        public User user
        {
            get { return _user; }
            set
            {
                this.RaiseAndSetIfChanged(ref _user, value);
            }
        }

        private double _textSizeHeader = 70;

        public double buttonFontHeader
        {
            get => _textSizeHeader;
            set
            {
                this.RaiseAndSetIfChanged(ref _textSizeHeader, value);
            }
        }

        private bool _isMobile = false;
        public bool IsMobile
        {
            get => _isMobile;
            set
            {
                this.RaiseAndSetIfChanged(ref _isMobile, value);
            }
        }

        private double _fieldFontSize = 50;

        public double FieldFontSize
        {
            get => _fieldFontSize;
            set
            {
                this.RaiseAndSetIfChanged(ref _fieldFontSize, value);
            }
        }

        private double _fieldWidth = 400;

        public double FieldWidth
        {
            get => _fieldWidth;
            set
            {
                this.RaiseAndSetIfChanged(ref _fieldWidth, value);
            }
        }

        private string _name ="";
        public string NameSignUp
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                }
            }
        }

        private string _textBoxText;

        public string TextBoxText
        {
            get => _textBoxText;
            set
            {
                if (_textBoxText != value)
                {
                    _textBoxText = value;
                }
            }
        }

        private string _password = "";
        public string PasswordSignUp
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                }
            }
        }

        private string _ErrorNameSignUp = "";
        public string ErrorNameSignUp
        {
            get { return _ErrorNameSignUp; }
            set
            {
                this.RaiseAndSetIfChanged(ref _ErrorNameSignUp, value);
            }
        }

        private string _ErrorPasswordSignUp = "";
        public string ErrorPasswordSignUp
        {
            get { return _ErrorPasswordSignUp; }
            set
            {
                this.RaiseAndSetIfChanged(ref _ErrorPasswordSignUp, value);
            }
        }

        private MainViewModel _MainViewModel;
        public MainViewModel MainViewModel { get { return _MainViewModel; } set { _MainViewModel = value; } }

        public SignUpViewModel(MainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
            SignUpFuncCommand = ReactiveCommand.Create(SignUpFunc);
        }

        public ICommand SignUpFuncCommand { get; }

        public void SignUpFunc()
        {
            System.Diagnostics.Debug.WriteLine("Sign up active. Name: " + NameSignUp + " Password: " + PasswordSignUp);
            SignUpFuncAsync();
        }

        public async void SignUpFuncAsync()
        {
            char[] charactersToCheck = { ' ' };
            if (NameSignUp.Length > 0)
            {
                ErrorNameSignUp = "";
                if (PasswordSignUp.Length > 0)
                {
                    ErrorPasswordSignUp = "";
                    bool containsCharactersName = charactersToCheck.Any(c => NameSignUp.Contains(c));
                    bool containsCharactersPassword = charactersToCheck.Any(c => PasswordSignUp.Contains(c));
                    if (!(containsCharactersName) && !(containsCharactersPassword))
                    {
                        ErrorPasswordSignUp = "";
                        System.Diagnostics.Debug.WriteLine("Sign up Correct");

                        DataBase db = new DataBase();
                        if (IsMobile)
                        {
                            db.IsMobile = true;
                        }

                        await db.insertUser(NameSignUp.ToLower(), PasswordSignUp);

                        User user = await db.getUserIdByName(NameSignUp.ToLower());
                        System.Diagnostics.Debug.WriteLine("User: " + user.Id_user.ToString() + " " + user.Name + " " + user.Password);

                        MainViewModel.LogIn = "Log out";
                        MainViewModel.SetUserId(user.Id_user);
                        MainViewModel.NavigateHome();
                        // вот здесь тип ты крутой и переход на другую страницу
                    }
                    else
                    {
                        ErrorPasswordSignUp = "Поля не могут содержать пробелы";
                    }
                }
                else
                {
                    ErrorPasswordSignUp = "Пароль не может быть пустым";
                }
            }
            else
            {
                ErrorNameSignUp = "Логин не может быть пустым";
            }
        }        
    }
}
