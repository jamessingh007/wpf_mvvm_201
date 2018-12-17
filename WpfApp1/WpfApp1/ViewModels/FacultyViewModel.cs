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
    public class FacultyViewModel : FacultyVM
    {
        TrainingContext _dbcontext = new TrainingContext();
        public FacultyVM SelectedFaculty
        {
            get;
            set;
        }

        private ObservableCollection<FacultyVM> _Faculties;
        public FacultyViewModel()
        {
            GetData();

        }

        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<FacultyVM> Faculties
        {
            //get;set;
            get { return _Faculties; }
            set { _Faculties = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected void GetData()
        {
            ObservableCollection<FacultyVM> _faculty = new ObservableCollection<FacultyVM>();
            var faculties = _dbcontext.FACULTies.Take(10).OrderByDescending(o => o.FacultyID).ToList();
            foreach (FACULTY prod in faculties)
            {
                _faculty.Add(new FacultyVM { objFaculty = prod });
            }
            Faculties = _faculty;
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateFacultyChanges()
        {
            _dbcontext.SaveChanges(); 
        }

        /// <summary>
        ///
        /// </summary>
        private ICommand Update;
        public ICommand UpdateFacultyCommand
        {
            get
            {
                if (Update == null)
                    Update = new RelayCommand(UpdateFacultyChanges);
                return Update;
            }

        }

        private void DeleteFaculty()
        {
            if(SelectedFaculty != null)
            {
                _dbcontext.FACULTies.Remove(SelectedFaculty.objFaculty);
                Faculties.Remove(SelectedFaculty);
                _dbcontext.SaveChanges();
            }
            
            
        }

        /// <summary>
        /// 
        /// </summary>
        private ICommand Delete;
        public ICommand DeleteFacultyCommand
        {
            get
            {
                if (Delete == null)
                    Delete = new RelayCommand(DeleteFaculty);
                return Delete;
            }

        }

        /// <summary>
        /// 
        /// </summary>
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
