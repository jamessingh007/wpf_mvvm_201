using System;
using System.ComponentModel;
using System.Windows;

namespace WpfApp1.ViewModels.DTO
{
    class LoginVM : INotifyPropertyChanged
    {
        ADMIN objadmin;
        public static string EnteredKey;
        public LoginVM()
        {
            objadmin = new ADMIN();
        }

        public string Username
        {
            get
            {
                return objadmin.Username;
            }
            set
            {
                objadmin.Username = value;
                OnPropertyChanged("Username");
            }
        }

        public string Password
        {
            get
            {
                return objadmin.Password;
            }
            set
            {
                if(EnteredKey == "")
                {
                    objadmin.Password = "";
                }
                else
                {
                    if (EnteredKey.Contains("*"))
                    {
                        objadmin.Password = objadmin.Password.Substring(0, objadmin.Password.Length - 1);
                    }
                    if(!EnteredKey.Contains("*"))
                    {
                        objadmin.Password += EnteredKey;
                    }
                }
                OnPropertyChanged("Password");
            }
        }

        private Visibility _WindowlVisible;
        public Visibility WindowlVisible
        {
            get
            {
                return _WindowlVisible;
            }
            set
            {
                _WindowlVisible = value;
                OnPropertyChanged("WindowlVisible");
            }
        }

        private Visibility _BadCredentials;
        public Visibility BadCredentials
        {
            get
            {
                return _BadCredentials;
            }
            set
            {
                _BadCredentials = value;
                OnPropertyChanged("BadCredentials");
            }
        }


        #region INotifyPropertyChanged members
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion 
    }
}
