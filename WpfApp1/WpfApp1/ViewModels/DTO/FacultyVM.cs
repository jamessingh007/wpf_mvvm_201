using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WpfApp1.ViewModels
{
    public class FacultyVM : INotifyPropertyChanged
    {
        public FACULTY objFaculty;

        public FacultyVM()
        {
            objFaculty = new FACULTY();
        }
        
        public int FacultyID
        {
            get
            {
                return objFaculty.FacultyID;
            }
            set
            {
                objFaculty.FacultyID = value;
            }
        }
        public String FacultyName
        {
            get
            {
                return objFaculty.FacultyName;
            }
            set
            {
                objFaculty.FacultyName = value;
            }
        }
        public string DateOfBirth
        {
            get
            {
                return objFaculty.DateOfBirth.ToString();
            }
            set
            {
                objFaculty.DateOfBirth = Convert.ToDateTime(value);
            }
        }
        public int Experience
        {
            get
            {
                return Convert.ToInt16(objFaculty.Experience);
            }
            set
            {
                objFaculty.Experience = value;
            }
        }
        public String Qualification
        {
            get
            {
                return objFaculty.Qualification;
            }
            set
            {
                objFaculty.Qualification = value;
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
