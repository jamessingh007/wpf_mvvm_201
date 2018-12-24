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
using System.Windows;
using WpfApp1.Views;
using System.Data.SqlClient;




namespace WpfApp1.ViewModels
{
    
    public class FacultyViewModel : Faculty
    {
        ExceptionHandling exObj = new ExceptionHandling();
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
        /// GetData()
        /// </summary>
        protected void GetData()
        {
            try
            {
                if (_Faculties.Count > 0)
                {
                    _Faculties.Clear();
                }
                var faculties = _dbcontext.FACULTies.Take(40).OrderByDescending(o => o.FacultyID).ToList();
                foreach (FACULTY prod in faculties)
                {
                    _Faculties.Add(new Faculty { objFaculty = prod });
                }
            }
            catch (Exception ex)
            {
                exObj.ShowExMsg(ex.InnerException);
                
            }
            
        }
        /// <summary>
        /// GenerateFacultyID()
        /// </summary>
        /// <returns></returns>
        protected int GenerateFacultyID()
        {
            int fid = 0;
            try
            {
                if (_Faculties.Count > 0)
                {
                    fid = _Faculties.First().FacultyID;
                }
                fid++;
            }
            catch (Exception ex)
            {

                exObj.ShowExMsg(ex.InnerException);
            }
            return fid;
        }

        /// <summary>
        /// Update faculty
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
        private void UpdateFacultyChanges()
        {
            try
            {
                _dbcontext.SaveChanges();
            }
            catch (Exception ex)
            {

                exObj.ShowExMsg(ex.InnerException);
            }
        }

        /// <summary>
        /// Search faculty
        /// </summary>
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
        private void SearchFaculty()
        {
            try
            {
                int _searchId = 0; 
                if (SearchKeyword.All(char.IsDigit))
                {
                    _searchId = Convert.ToInt16(SearchKeyword);
                }
                if (_Faculties.Count > 0)
                {
                    _Faculties.Clear();
                }
                var faculties = _dbcontext.FACULTies.Where(x => x.FacultyName.Contains(SearchKeyword) || x.FacultyID == _searchId);
                if (faculties.Count() > 0)
                {
                    foreach (FACULTY prod in faculties)
                    {
                        _Faculties.Add(new Faculty { objFaculty = prod });
                    }
                }
                else
                {
                    MessageBox.Show("No records found.", "Search Result",MessageBoxButton.OK);
                }
            }
            catch (Exception ex)
            {
                exObj.ShowExMsg(ex.InnerException);
            }
        }

        /// <summary>
        /// ADD faculty
        /// </summary>
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
        private void AddFaculty()
        {
            try
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
            catch (Exception ex)
            {
                exObj.ShowExMsg(ex.InnerException);
            }
        }

        /// <summary>
        /// Delete Faculty
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
            try
            {
                if (SelectedFaculty != null)
                {
                    _dbcontext.FACULTies.Remove(SelectedFaculty.objFaculty);
                    Faculties.Remove(SelectedFaculty);
                    _dbcontext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                exObj.ShowExMsg(ex.InnerException);
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
