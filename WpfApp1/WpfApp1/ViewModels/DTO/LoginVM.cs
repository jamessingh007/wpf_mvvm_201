using System.ComponentModel;

namespace WpfApp1.ViewModels.DTO
{
    class LoginVM : INotifyPropertyChanged
    {
        public ADMIN objAdmin;

        public LoginVM()
        {
            objAdmin = new ADMIN();
        }
            
        public string Username
        {
            get
            {
                return objAdmin.Username;
            }
            set
            {
                objAdmin.Username = value;
                OnPropertyChanged("Username");
            }
        }


        public string Password
        {
            get
            {
                return objAdmin.Password;
            }
            set
            {
                objAdmin.Password = value;
                OnPropertyChanged("Password");
            }
        }
        
        #region INotifyPropertyChanged members
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
