using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using WpfApp1.ViewModels.DTO;
using System.Data.Entity;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WpfApp1
{
    public class FacultyViewModel : INotifyPropertyChanged
    {
        /*
        private FACULTY objFaculty = new FACULTY();

        public int FacultyID {
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
        */

        protected TrainingContext db = new TrainingContext();

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<FacultyVM> Faculties { get; set; }

        protected void GetFaculty()
        {
            ObservableCollection<FacultyVM> _faculties = new ObservableCollection<FacultyVM>();
            var faculties = (from f in db.FACULTies
                             select f).ToList();
            foreach(FACULTY faculty in faculties)
            {
                _faculties.Add(new FacultyVM { TheFaculty = faculty});
            }
            Faculties = _faculties;
        }


        public FacultyViewModel() :base()
        {

        }
    }
}
