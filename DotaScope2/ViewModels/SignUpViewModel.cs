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
                        db.insertUser(NameSignUp, PasswordSignUp);

                        int id = db.getUserIdDb(NameSignUp);
                        MainViewModel.LogIn = "Log out";
                        MainViewModel.SetUserId(id);
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
