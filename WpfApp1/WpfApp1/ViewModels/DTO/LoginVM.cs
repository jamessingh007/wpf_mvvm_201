using System;
using System.ComponentModel;

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
                objadmin.Password += EnteredKey;
                OnPropertyChanged("Password");
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
