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
        private string _name = "";
        public string Name
        {
            get { return _name; }
            private set
            {
                this.RaiseAndSetIfChanged(ref _name, value);
            }
        }

        private string _password = "";
        public string Password
        {
            get { return _password; }
            private set
            {
                this.RaiseAndSetIfChanged(ref _password, value);
            }
        }

        public void SignUpFunc()
        {
            char[] charactersToCheck = { ' ', '?', ',', '$', '@', '#', '%', '.' };
            if (Password.Length > 0)
            {
                if (Name.Length > 0)
                {
                    bool containsCharactersName = charactersToCheck.Any(c => Name.Contains(c));
                    bool containsCharactersPassword = charactersToCheck.Any(c => Password.Contains(c));
                    if (!(containsCharactersName) && !(containsCharactersPassword))
                    {
                        // вот здесь тип ты крутой и переход на другую страницу
                    }
                }
            }
        }
    }
}
