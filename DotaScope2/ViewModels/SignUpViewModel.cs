using DotaScope2.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace DotaScope2.ViewModels
{
    internal class SignUpViewModel : ViewModelBase
    {
        private string _name ;
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

        private string _password;
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

        public void SignUpFunc()
        {
            System.Diagnostics.Debug.WriteLine("Sign up active. Name: " + NameSignUp + " Password: " + PasswordSignUp);
            char[] charactersToCheck = { ' ', '?', ',', '$', '@', '#', '%', '.' };
            if (PasswordSignUp.Length > 0)
            {
                if (NameSignUp.Length > 0)
                {
                    bool containsCharactersName = charactersToCheck.Any(c => NameSignUp.Contains(c));
                    bool containsCharactersPassword = charactersToCheck.Any(c => PasswordSignUp.Contains(c));
                    if (!(containsCharactersName) && !(containsCharactersPassword))
                    {
                        System.Diagnostics.Debug.WriteLine("Sign up Correct");

                        DataBase db = new DataBase();
                        db.insertUser(NameSignUp, PasswordSignUp);

                        int id = db.getUser(NameSignUp);
                        MainViewModel mainViewModel = new MainViewModel();
                        mainViewModel.NavigateHome();
                        // вот здесь тип ты крутой и переход на другую страницу
                    }
                }
            }
        }
    }
}
