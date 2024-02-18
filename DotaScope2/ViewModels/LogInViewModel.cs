using Avalonia.Interactivity;
using DotaScope2.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DotaScope2.ViewModels
{
    internal class LogInViewModel : NavigationViewModel
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

        private bool _isPC = true;
        public bool isPC
        {
            get => _isPC;
            set
            {
                this.RaiseAndSetIfChanged(ref _isPC, value);
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

        private string _name = "";
        public string NameLoginIn
        {
            get { return _name; }
            set
            {
                this.RaiseAndSetIfChanged(ref _name, value);
            }
        }

        private string _password = "";
        public string PasswordLoginIn
        {
            get { return _password; }
            set
            {
                this.RaiseAndSetIfChanged(ref _password, value);
            }
        } 
        
        private string _ErrorNameLoginIn = "";
        public string ErrorNameLoginIn
        {
            get { return _ErrorNameLoginIn; }
            set
            {
                this.RaiseAndSetIfChanged(ref _ErrorNameLoginIn, value);
            }
        }  
        
        private string _ErrorPasswordLoginIn = "";
        public string ErrorPasswordLoginIn
        {
            get { return _ErrorPasswordLoginIn; }
            set
            {
                this.RaiseAndSetIfChanged(ref _ErrorPasswordLoginIn, value);
            }
        }

        private MainViewModel _MainViewModel;
        public MainViewModel MainViewModel { get { return _MainViewModel; } set { _MainViewModel = value; } }

        public LogInViewModel(MainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
            LoginFuncCommand = ReactiveCommand.Create(LoginFunc);

        }

        public ICommand LoginFuncCommand { get; }

        public void LoginFunc()
        {

            System.Diagnostics.Debug.WriteLine("Login In active. Name: " + NameLoginIn + " Password: " + PasswordLoginIn);
            LoginFuncAsync();
        }
           
        public async void LoginFuncAsync()
        {
                char[] charactersToCheck = { ' ' };
                if (NameLoginIn.Length > 0)
                {
                    ErrorNameLoginIn = "";
                    if (PasswordLoginIn.Length > 0)
                    {
                        ErrorPasswordLoginIn = "";
                        System.Diagnostics.Debug.WriteLine("Sign up Correct");

                        DataBase db = new DataBase();

                        User user = await db.getUserIdByName(NameLoginIn.ToLower());
                        if (user != null)
                        {
                            ErrorNameLoginIn = "";
                            string pas = user.Password;
                            if (PasswordLoginIn == pas)
                            {
                                MainViewModel.LogIn = "Log Out";
                                MainViewModel.SetUserId(user.Id_user);
                                MainViewModel.NavigateHome();
                            }
                            else
                            {
                                ErrorPasswordLoginIn = "Неверный пароль";
                            }
                        }
                        else
                        {
                            ErrorNameLoginIn = "Неверный логин";
                        }
                        // вот здесь тип ты крутой и переход на другую страницу
                    }
                    else
                    {
                        ErrorPasswordLoginIn = "Пароль не может быть пустым";
                    }
                }
                else
                {
                    ErrorNameLoginIn = "Логин не может быть пустым";
                }
            }
        }

    }

