using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace WpfApp1.ViewModels
{
    class BatchViewModel : Batch
    {
        ExceptionHandling exObj = new ExceptionHandling();
        TrainingContext _dbcontext = new TrainingContext();
        public ObservableCollection<string> StreamCollection { get; set; }
        public ObservableCollection<string> FacultyIDCollection { get; set; }
        public ObservableCollection<string> _colFacultyID =  new ObservableCollection<string>();

        public Batch SelectedBatch
        {
            get;
            set;
        }
        public BatchViewModel()
        {
            GetData();
            PopulateParticpantComboxValue();
            PopulateFacultyIDComboboxValue();
        }

        private void PopulateFacultyIDComboboxValue()
        {
            try
            {
                FacultyIDCollection = _colFacultyID;
            }
            catch (Exception ex)
            {
                exObj.ShowExMsg(ex.InnerException);
            }
        }

        private void PopulateParticpantComboxValue()
        {
            try
            {
                StreamCollection = new ObservableCollection<string>() { "Science", "Arts", "Commerce"};
            }
            catch (Exception ex)
            {
                exObj.ShowExMsg(ex.InnerException);
            }
        }

        private ObservableCollection<Batch> _Batches = new ObservableCollection<Batch>();
        public ObservableCollection<Batch> Batches
        {
            get { return _Batches; }
            set { _Batches = value; }
        }

        /// <summary>
        /// GetData()
        /// </summary>
        protected void GetData()
        {
            try
            {
                if (_Batches.Count > 0)
                {
                    _Batches.Clear();
                }
                var batches = _dbcontext.BATCHes.Take(40).OrderByDescending(o => o.BatchID).ToList();
                foreach (BATCH batch in batches)
                {
                    _Batches.Add(new Batch { objBatch = batch });
                }
                var facultiesID = _dbcontext.FACULTies.ToList();
                foreach (FACULTY fid in facultiesID)
                {
                    _colFacultyID.Add(fid.FacultyID.ToString() + "-" + fid.FacultyName.ToString());
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
        protected int GenerateBatchID()
        {
            int bid = 0;
            try
            {
                if (_Batches.Count > 0)
                {
                    bid = _Batches.First().BatchID;
                }
                bid++;
            }
            catch (Exception ex)
            {

                exObj.ShowExMsg(ex.InnerException);
            }
            return bid;
        }
        /// <summary>
        /// 
        /// </summary>
        private ICommand Search;
        public ICommand SearchBatchCommand
        {
            get
            {
                if (Search == null)
                    Search = new RelayCommand(SearchBatch);
                return Search;
            }

        }
        /// <summary>
        /// Update faculty
        /// </summary>
        private ICommand Update;
        public ICommand UpdateBatchCommand
        {
            get
            {
                if (Update == null)
                    Update = new RelayCommand(UpdateBatchChanges);
                return Update;
            }
        }
        private void UpdateBatchChanges()
        {
            try
            {
                if (MessageBox.Show("Dp you want to update the selected Batch?", "Confirm Update", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    _dbcontext.SaveChanges();
                }
                else
                {
                    _dbcontext = new TrainingContext();
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
        private ICommand SelectionChanged;
        public ICommand FacultyIDChangedCommand
        {
            get
            {
                if (SelectionChanged == null)
                    SelectionChanged = new RelayCommand(FacultyIDChanged);
                return SelectionChanged;
            }
        }

        private void FacultyIDChanged()
        {
            try
            {
                Nullable<int> selectedid = Convert.ToInt16(SelectedFacultyID.ToString().Split('-')[0]);
                FacultyID = selectedid;
            }
            catch (Exception ex)
            {

                exObj.ShowExMsg(ex.InnerException);
            }
        }

        private void SearchBatch()
        {
            try
            {
                int _searchId = 0;
                if (SearchKeyword.All(char.IsDigit))
                {
                    _searchId = Convert.ToInt16(SearchKeyword);
                }
                if (_Batches.Count > 0)
                {
                    _Batches.Clear();
                }
                var batches = _dbcontext.BATCHes.Where(x => x.BatchID == _searchId);
                if (batches.Count() > 0)
                {
                    foreach (BATCH batch in batches)
                    {
                        _Batches.Add(new Batch { objBatch = batch });
                    }
                }
                else
                {
                    MessageBox.Show("No records found.", "Search Result", MessageBoxButton.OK);
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
        public ICommand AddBatchCommand
        {
            get
            {
                if (Add == null)
                    Add = new RelayCommand(AddBatch);
                return Add;
            }
        }
        private void AddBatch()
        {
            try
            {
                if (MessageBox.Show("Do you want to add the new Batch?", "Confirm Add", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    BATCH _newBatch = new BATCH();
                    _newBatch.BatchID = GenerateBatchID();
                    _newBatch.BatchStartDate = BatchStartDate;
                    _newBatch.BatchEndDate = BatchEndDate;
                    _newBatch.Stream = (string)Stream;
                    _newBatch.FacultyID = FacultyID;
                    _dbcontext.BATCHes.Add(_newBatch);
                    _dbcontext.SaveChanges();
                    GetData();
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
                BatchStartDate = null;
                BatchEndDate = null;
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
        public ICommand DeleteBatchCommand
        {
            get
            {
                if (Delete == null)
                    Delete = new RelayCommand(DeleteBatch);
                return Delete;
            }

        }
        private void DeleteBatch()
        {
            try
            {
                if (SelectedBatch != null)
                {
                    if (MessageBox.Show("Dp you want to delete the selected Batch?", "Confirm Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        _dbcontext.BATCHes.Remove(SelectedBatch.objBatch);
                        Batches.Remove(SelectedBatch);
                        _dbcontext.SaveChanges();
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
