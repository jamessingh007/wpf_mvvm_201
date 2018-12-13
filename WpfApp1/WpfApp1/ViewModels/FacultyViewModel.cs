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
using WpfApp1.Views;

namespace WpfApp1.ViewModels
{
    public class FacultyViewModel
    {
        TrainingContext _dbcontext = new TrainingContext();

        private ObservableCollection<FacultyVM> _Faculties;
        public FacultyViewModel()
        {
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
            var faculties = _dbcontext.FACULTies.Take(5).OrderByDescending(o => o.FacultyID).ToList();
            foreach (FACULTY prod in faculties)
            {
                _faculty.Add(new FacultyVM { objFaculty = prod });
            }
            Faculties = _faculty;
        }

        private void SaveFacultyChanges()
        {

            _dbcontext.SaveChanges(); 
        }

        private ICommand mUpdater;
        public ICommand SaveFacultyCommand
        {
            get
            {
                if (mUpdater == null)
                    mUpdater = new RelayCommand(SaveFacultyChanges);
                return mUpdater;
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
