using System;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp1.ViewModels.DTO;

namespace WpfApp1.ViewModels
{
    class LoginViewModel : LoginVM
    {
        private ICommand _LoginCommand;
        public ICommand LoginCommand
        {
            get
            {
                if(_LoginCommand == null)
                {
                    _LoginCommand = new RelayCommand(param => this.Login());
                }
                return _LoginCommand;
            }
        }

        private void Login()
        {
            
        }

        public class RelayCommand : ICommand
        {
            #region ICommand Members

            private Action<object> _action;
            public RelayCommand(Action<object> action)
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
                var pwdBox = parameter as PasswordBox;
                var pwd = pwdBox.Password;
                _action(pwd);
            }

            #endregion
        }

    }
}
