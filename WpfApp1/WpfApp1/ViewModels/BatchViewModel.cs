using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Views;

namespace WpfApp1.ViewModels
{
    class BatchViewModel : Batch
    {
        ExceptionHandling exObj = new ExceptionHandling();
        public ObservableCollection<string> StreamCollection { get; set; }
        public ObservableCollection<string> FacultyIDCollection { get; set; }
        public ObservableCollection<string> _colFacultyID =  new ObservableCollection<string>();
        private ObservableCollection<Batch> _Batches = new ObservableCollection<Batch>();
        private ObservableCollection<ParticipantVM> _Participants = new ObservableCollection<ParticipantVM>();

        public Batch SelectedBatch
        {
            get;
            set;
        }
        public BatchViewModel()
        {
            GetData();
            PopulateStreamComboxValue();
            PopulateFacultyIDComboboxValue();
        }

        private void PopulateFacultyIDComboboxValue()
        {
            try
            {
                var facultiesID = Common.Courses._dbcontext.FACULTies.ToList();
                foreach (FACULTY fid in facultiesID)
                {
                    _colFacultyID.Add(fid.FacultyID.ToString() + "-" + fid.FacultyName.ToString());
                }
                FacultyIDCollection = _colFacultyID;
            }
            catch (Exception ex)
            {
                exObj.ShowExMsg(ex.InnerException);
            }
        }

        private void PopulateStreamComboxValue()
        {
            try
            {
                StreamCollection = Common.Courses.Course;
            }
            catch (Exception ex)
            {
                exObj.ShowExMsg(ex.InnerException);
            }
        }

        
        public ObservableCollection<Batch> Batches
        {
            get { return _Batches; }
            set { _Batches = value; }
        }

        public ObservableCollection<ParticipantVM> Participants
        {
            get { return _Participants; }
            set { _Participants = value; }
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
                var batches = Common.Courses._dbcontext.BATCHes.Take(40).OrderByDescending(o => o.BatchID).ToList();
                foreach (BATCH batch in batches)
                {
                    _Batches.Add(new Batch { objBatch = batch });
                }
                
            }
            catch (Exception ex)
            {
                exObj.ShowExMsg(ex.InnerException);
            }
        }
        /// <summary>
        /// GenerateBatchID()
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
        /// show add participant view
        /// </summary>
        private ICommand _ShowAddParticipant;
        public ICommand ShowAddParticipantCommand
        {
            get
            {
                if (_ShowAddParticipant == null)
                    _ShowAddParticipant = new RelayCommand(ShowAddParticipant);
                return _ShowAddParticipant;
            }
        }

        private void ShowAddParticipant()
        {
            AddParticipantView obj = new AddParticipantView();
            obj.Show();
        }
        /// <summary>
        /// Search
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
                var batches = Common.Courses._dbcontext.BATCHes.Where(x => x.BatchID == _searchId);
                if (batches.Count() > 0)
                {
                    foreach (BATCH batch in batches)
                    {
                        _Batches.Add(new Batch { objBatch = batch });
                        var participants = Common.Courses._dbcontext.PARTICIPANTs.Where(x => x.BatchID == _searchId);
                        if (participants.Count() > 0)
                        {
                            foreach (PARTICIPANT participant in participants)
                            {
                                _Participants.Add(new ParticipantVM { objParticipant = participant });
                            }
                        }
                        else
                        {
                            MessageBox.Show("No participants present in this batch.", "Search Result", MessageBoxButton.OK);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No records found.", "Search Result", MessageBoxButton.OK);
                    GetData();
                }
            }
            catch (Exception ex)
            {
                exObj.ShowExMsg(ex.InnerException);
            }
        }

        /// <summary>
        /// Update batch
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
        /// ADD batch
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
                    _newBatch.BatchDescription = BatchDescription;
                    _newBatch.BatchStartDate = BatchStartDate;
                    _newBatch.BatchEndDate = BatchEndDate;
                    _newBatch.Stream = (string)Stream;
                    _newBatch.FacultyID = FacultyID;
                    Common.Courses._dbcontext.BATCHes.Add(_newBatch);
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
                BatchStartDate = null;
                BatchEndDate = null;

            }
            catch (Exception ex)
            {
                exObj.ShowExMsg(ex);
            }
        }

        /// <summary>
        /// Delete batch
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
                        Common.Courses._dbcontext.BATCHes.Remove(SelectedBatch.objBatch);
                        Batches.Remove(SelectedBatch);
                        Common.Courses._dbcontext.SaveChanges();
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
