using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using WpfApp1.ViewModels.DTO;

namespace WpfApp1.ViewModels
{
    class ParticipantViewModel : ParticipantVM
    {
        ExceptionHandling exObj = new ExceptionHandling();
        public ObservableCollection<BatchCourses> BatchIDCollection { get; set; }
        public ObservableCollection<string> _batchIDCollection = new ObservableCollection<string>();
        public ObservableCollection<string> StreamCollection { get; set; }
        private ObservableCollection<ParticipantVM> _Participants = new ObservableCollection<ParticipantVM>();

        public ParticipantVM SelectedParticipant
        {
            get;
            set;
        }
        public ParticipantViewModel()
        {
            GetData();
            PopulateStreamComboxValue();
            PopulateBatchIDComboboxValue();
        }

        private void PopulateBatchIDComboboxValue()
        {
            try
            {
                var data = Common.Courses._dbcontext.BATCHes.ToList();
                BatchIDCollection = new ObservableCollection<BatchCourses>();
                foreach (BATCH bid in data)
                {
                    BatchIDCollection.Add(
                        new BatchCourses()
                        {
                            BatchID = bid.BatchID,
                            CourseName = bid.BatchDescription
                        }
                    );
                }
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
                if (_Participants.Count > 0)
                {
                    _Participants.Clear();
                }
                var participants = Common.Courses._dbcontext.PARTICIPANTs.Take(40).OrderByDescending(o => o.ParticipantID).ToList();
                foreach (PARTICIPANT participant in participants)
                {
                    _Participants.Add(new ParticipantVM { objParticipant = participant });
                }
            }
            catch (Exception ex)
            {
                exObj.ShowExMsg(ex.InnerException);
            }
        }
        /// <summary>
        /// GenerateParticipantID()
        /// </summary>
        /// <returns></returns>
        protected int GenerateParticipantID()
        {
            int bid = 0;
            try
            {
                if (_Participants.Count > 0)
                {
                    bid = _Participants.First().ParticipantID;
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
        /// SearchParticipant
        /// </summary>
        private ICommand Search;
        public ICommand SearchParticipantCommand
        {
            get
            {
                if (Search == null)
                    Search = new RelayCommand(SearchParticipant);
                return Search;
            }

        }
        /// <summary>
        /// Update batch
        /// </summary>
        private ICommand Update;
        public ICommand UpdateParticipantCommand
        {
            get
            {
                if (Update == null)
                    Update = new RelayCommand(UpdateParticipantChanges);
                return Update;
            }
        }
        private void UpdateParticipantChanges()
        {
            try
            {
                if (MessageBox.Show("Dp you want to update the selected Participant?", "Confirm Update", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
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


        private void SearchParticipant()
        {
            try
            {
                int _searchId = 0;
                if (SearchKeyword.All(char.IsDigit))
                {
                    _searchId = Convert.ToInt16(SearchKeyword);
                }
                if (_Participants.Count > 0)
                {
                    _Participants.Clear();
                }
                var participants = Common.Courses._dbcontext.PARTICIPANTs.Where(x => x.ParticipantID == _searchId);
                if (participants.Count() > 0)
                {
                    foreach (PARTICIPANT batch in participants)
                    {
                        _Participants.Add(new ParticipantVM { objParticipant = batch });
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
        /// ADD participant
        /// </summary>
        private ICommand Add;
        public ICommand AddParticipantCommand
        {
            get
            {
                if (Add == null)
                    Add = new RelayCommand(AddParticipant);
                return Add;
            }
        }
        private void AddParticipant()
        {
            try
            {
                if (MessageBox.Show("Do you want to add the new Participant?", "Confirm Add", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    PARTICIPANT _newParticipant = new PARTICIPANT();
                    _newParticipant.ParticipantID = GenerateParticipantID();
                    _newParticipant.ParticipantName = ParticipantName;
                    _newParticipant.DateOfBirth = DateOfBirth;
                    _newParticipant.CourseRegistered = CourseRegistered;
                    _newParticipant.BatchID = BatchID;
                    _newParticipant.DateofRegistration = DateofRegistration;
                    Common.Courses._dbcontext.PARTICIPANTs.Add(_newParticipant);
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
                DateofRegistration = null;
                DateOfBirth = null;
            }
            catch (Exception ex)
            {
                exObj.ShowExMsg(ex);
            }
        }

        /// <summary>
        /// Delete Participant
        /// </summary>
        private ICommand Delete;
        public ICommand DeleteParticipantCommand
        {
            get
            {
                if (Delete == null)
                    Delete = new RelayCommand(DeleteParticipant);
                return Delete;
            }

        }
        private void DeleteParticipant()
        {
            try
            {
                if (SelectedParticipant != null)
                {
                    if (MessageBox.Show("Dp you want to delete the selected Participant?", "Confirm Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        Common.Courses._dbcontext.PARTICIPANTs.Remove(SelectedParticipant.objParticipant);
                        _Participants.Remove(SelectedParticipant);
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
