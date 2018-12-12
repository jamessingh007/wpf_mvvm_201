using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using WpfApp1.ViewModels.DTO;
using System.Data.Entity;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace WpfApp1.ViewModels
{
    public class FacultyViewModel
    {
        TrainingContext _dbcontext = new TrainingContext();

        private ObservableCollection<FacultyVM> _Faculties;
        public FacultyViewModel()
        {
            //_Faculties = new ObservableCollection<FacultyVM>
            //{
            //    new FacultyVM{FacultyID = 1,FacultyName="Raj",DateOfBirth="2012/02/01",Experience=3,Qualification="DEL"},
            //    new FacultyVM{FacultyID=2,FacultyName="Mark",DateOfBirth="2012/02/01",Experience=5, Qualification="NY"},
            //    new FacultyVM{FacultyID=3,FacultyName="Mahesh",DateOfBirth="2012/02/01",Experience=4, Qualification="PHL"},
            //    new FacultyVM{FacultyID=4,FacultyName="Vikash",DateOfBirth="2012/02/01",Experience=6, Qualification="UP"},
            //    new FacultyVM{FacultyID=5,FacultyName="Harsh",DateOfBirth="2012/02/01",Experience=2, Qualification="UP"},
            //    new FacultyVM{FacultyID=6,FacultyName="Reetesh",DateOfBirth="2012/02/01",Experience=1, Qualification="MP"},
            //    new FacultyVM{FacultyID=7,FacultyName="Deven",DateOfBirth="2012/02/01",Experience=3, Qualification="HP"},
            //    new FacultyVM{FacultyID=8,FacultyName="Ravi",DateOfBirth="2012/02/01",Experience=4, Qualification="DEL"}
            //};
            GetData();
        }
        public ObservableCollection<FacultyVM> Faculties
        {
            get { return _Faculties; }
            set { _Faculties = value; }
        }

        protected void GetData()
        {
            ObservableCollection<FacultyVM> _faculty = new ObservableCollection<FacultyVM>();
            var faculties = (from p in _dbcontext.FACULTies
                                  select p).ToList();
            foreach (FACULTY prod in faculties)
            {
                _faculty.Add(new FacultyVM {objFaculty = prod });
            }
            Faculties = _faculty;
        }
        private ICommand mUpdater;
        public ICommand UpdateCommand
        {
            get
            {
                if (mUpdater == null)
                    mUpdater = new Updater();
                return mUpdater;
            }
            set
            {
                mUpdater = value;
            }
        }

        private class Updater : ICommand
        {
            #region ICommand Members

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {

            }

            #endregion
        }
        
    }
}
