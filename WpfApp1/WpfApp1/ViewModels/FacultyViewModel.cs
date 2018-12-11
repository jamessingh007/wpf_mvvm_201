using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using WpfApp1.ViewModels.DTO;
using System.Data.Entity;
using System.Collections.ObjectModel;

namespace WpfApp1
{
    public class FacultyViewModel
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

        public ObservableCollection<FacultyVM> Faculties { get; set; }
        public FacultyViewModel() :base()
        {

        }
    }
}
