using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using WpfApp1.ViewModels.DTO;

namespace WpfApp1.ViewModels
{
    class LoginViewModel : LoginVM
    {
        ExceptionHandling exObj = new ExceptionHandling();

        private ICommand _loginCommand;
        public ICommand LoginCommmand
        {
            get
            {
                if (_loginCommand == null)
                {
                    _loginCommand = new RelayCommand(LoginSubmit);
                }
                return _loginCommand;
            }
        }

        private void LoginSubmit()
        {
            //MessageBox.Show(Password);
            var adminCred = Common.Courses._dbcontext.ADMINs.ToList();
            if(adminCred.Count() > 0)
            {
                foreach (ADMIN cred in adminCred)
                {
                    if(Username == cred.Username && Password == cred.Password)
                    {
                        MainWindow objMainWindow = new MainWindow();
                        objMainWindow.Show();
                    }
                }
            }
        }

        public class RelayCommand : ICommand
        {
            #region ICommand Members

            private Action _action;
            public RelayCommand(Action action)
            {
                _action = action;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                _action();
            }

            #endregion
        }
    }
}
