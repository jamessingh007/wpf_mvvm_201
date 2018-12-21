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
using System.Windows;



namespace WpfApp1.ViewModels
{
    public class FacultyViewModel : Faculty
    {
        TrainingContext _dbcontext = new TrainingContext();
        public Faculty SelectedFaculty
        {
            get;
            set;
        }


        public FacultyViewModel()
        {
            GetData();
        }

        private ObservableCollection<Faculty> _Faculties = new ObservableCollection<Faculty>();
        public ObservableCollection<Faculty> Faculties
        {
            //get;set;
            get { return _Faculties; }
            set { _Faculties = value; }
        }

        private Faculty _newFaculty = new Faculty();
        public Faculty newFaculty
        {
            get { return _newFaculty; }
            set { _newFaculty = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected void GetData()
        {   
            if (_Faculties.Count > 0)
            {
                _Faculties.Clear();
            }
            var faculties = _dbcontext.FACULTies.Take(10).OrderByDescending(o => o.FacultyID).ToList();
            foreach (FACULTY prod in faculties)
            {
                _Faculties.Add(new Faculty { objFaculty = prod });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected int GenerateFacultyID()
        {
            int fid=0;
            if (_Faculties.Count > 0)
            {
                fid = _Faculties.First().FacultyID;
            }
            fid++;
            return fid;
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

        private ICommand Search;
        public ICommand SearchFacultyCommand
        {
            get
            {
                if (Search == null)
                    Search = new RelayCommand(SearchFaculty);
                return Search;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        private void SearchFaculty()
        {

        }

        private ICommand Add;
        public ICommand AddFacultyCommand
        {
            get
            {
                if (Add == null)
                    Add = new RelayCommand(AddFaculty);
                return Add;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void AddFaculty()
        {
            FACULTY _newFaculty = new FACULTY();
            _newFaculty.FacultyID = GenerateFacultyID();
            _newFaculty.FacultyName = FacultyName;
            _newFaculty.DateOfBirth = DateTime.Parse(DateOfBirth);
            _newFaculty.Experience = Experience;
            _newFaculty.Qualification = Qualification;
            _dbcontext.FACULTies.Add(_newFaculty);
            _dbcontext.SaveChanges();
            GetData();

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

        private void DeleteFaculty()
        {
            if (SelectedFaculty != null)
            {
                _dbcontext.FACULTies.Remove(SelectedFaculty.objFaculty);
                Faculties.Remove(SelectedFaculty);
                _dbcontext.SaveChanges();
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
