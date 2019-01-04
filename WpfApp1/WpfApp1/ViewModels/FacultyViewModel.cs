﻿using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Input;




namespace WpfApp1.ViewModels
{

    public class FacultyViewModel : Faculty
    {
        ExceptionHandling exObj = new ExceptionHandling();
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
                var faculties = Common.Courses._dbcontext.FACULTies.Take(40).OrderByDescending(o => o.FacultyID).ToList();
                foreach (FACULTY faculty in faculties)
                {
                    _Faculties.Add(new Faculty { objFaculty = faculty });
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
                if (MessageBox.Show("Dp you want to update the selected faculty?", "Confirm Update", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Common.Courses._dbcontext.SaveChanges();
                    MessageBox.Show("Record updated successfully");
                }
                else
                {
                    Common.Courses._dbcontext = new TrainingContext();
                    GetData();
                }
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
                bool isId = false;
                if (SearchKeyword.All(char.IsDigit))
                {
                    _searchId = Convert.ToInt16(SearchKeyword);
                }
                if (_Faculties.Count > 0)
                {
                    _Faculties.Clear();
                }
                var faculties = Common.Courses._dbcontext.FACULTies.Where(x => x.FacultyName.Contains(SearchKeyword) || x.FacultyID == _searchId).ToList();
                
                if (faculties.Count() > 0)
                {
                    foreach (FACULTY faculty in faculties)
                    {
                        _Faculties.Add(new Faculty { objFaculty = faculty });
                    }
                }
                else
                {
                    MessageBox.Show("No records found.", "Search Result",MessageBoxButton.OK);
                    GetData();
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
                if (MessageBox.Show("Dp you want to add the new faculty?", "Confirm Add", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    FACULTY _newFaculty = new FACULTY();
                    _newFaculty.FacultyID = GenerateFacultyID();
                    _newFaculty.FacultyName = FacultyName;
                    _newFaculty.DateOfBirth = DateOfBirth;
                    _newFaculty.Experience = Experience;
                    _newFaculty.Qualification = Qualification;
                    Common.Courses._dbcontext.FACULTies.Add(_newFaculty);
                    Common.Courses._dbcontext.SaveChanges();
                    GetData();
                    MessageBox.Show("Record added successfully");
                    ClearFills();
                }
            }
            catch (Exception ex)
            {
                exObj.ShowExMsg(ex.InnerException);
            }
        }

        private void ClearFills()
        {
            try
            {
                FacultyName = "";
                DateOfBirth = null;
                Experience = 0;
                Qualification = "";
            }
            catch (Exception ex)
            {
                exObj.ShowExMsg(ex);
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
                    if (MessageBox.Show("Dp you want to delete the selected faculty?", "Confirm Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        Common.Courses._dbcontext.FACULTies.Remove(SelectedFaculty.objFaculty);
                        Faculties.Remove(SelectedFaculty);
                        Common.Courses._dbcontext.SaveChanges();
                        GetData();
                        MessageBox.Show("Record deleted successfully");
                    }
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
