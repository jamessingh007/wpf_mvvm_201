using System;
using System.ComponentModel;
using WpfApp1.Common;

namespace WpfApp1.ViewModels
{
    class ParticipantVM : INotifyPropertyChanged
    {
        public PARTICIPANT objParticipant;
        private string _searchKeyword;
        private Nullable<int> _SelectedBatch;
        public ParticipantVM()
        {
            objParticipant = new PARTICIPANT();
        }

        public int ParticipantID
        {
            get
            {
                return objParticipant.ParticipantID;
            }
            set
            {
                objParticipant.ParticipantID = value;
            }
        }


        public string ParticipantName
        {
            get
            {
                return objParticipant.ParticipantName;
            }
            set
            {
                objParticipant.ParticipantName = value;
                OnPropertyChanged("ParticipantName");
            }
        }

        public Nullable<System.DateTime> DateOfBirth
        {
            get
            {

                var _bsd = objParticipant.DateOfBirth;
                Nullable<DateTime> bsd = null;
                if (_bsd != null)
                {
                    bsd = DateTime.Parse(_bsd.ToString()).Date;
                }
                return bsd;
            }
            set
            {
                if (value != null)
                {
                    string _bsd = Convert.ToString(value);
                    objParticipant.DateOfBirth = DateTime.Parse(_bsd).Date;
                    OnPropertyChanged("DateOfBirth");
                }
            }
        }

        public string CourseRegistered
        {
            get
            {
                return objParticipant.CourseRegistered;
            }
            set
            {

                objParticipant.CourseRegistered = value;
                OnPropertyChanged("CourseRegistered");
            }
        }

        public Nullable<System.DateTime> DateofRegistration
        {
            get
            {
                var _bed = objParticipant.DateofRegistration;
                Nullable<DateTime> bed = null;
                if (_bed != null)
                {
                    bed = DateTime.Parse(_bed.ToString()).Date;
                }
                return bed;
            }
            set
            {
                if (value != null)
                {
                    string _bed = Convert.ToString(value);
                    objParticipant.DateofRegistration = DateTime.Parse(_bed).Date;
                    OnPropertyChanged("DateofRegistration");
                }
            }
        }

        public string SearchKeyword
        {
            get
            {
                return _searchKeyword;
            }
            set
            {
                _searchKeyword = value;
                OnPropertyChanged("SearchKeyword");
            }
        }


        public Nullable<int> SelectedBatchID
        {
            get
            {
                return _SelectedBatch;
            }
            set
            {
                _SelectedBatch = value;
                objParticipant.BatchID = Convert.ToInt32(_SelectedBatch);
                OnPropertyChanged("SelectedBatchID");
                OnPropertyChanged("BatchID");

            }

        }

        public Nullable<int> BatchID
        {
            get
            {
                return objParticipant.BatchID;
            }
            set
            {
                objParticipant.BatchID = value;
                OnPropertyChanged("BatchID");
            }
        }


        #region INotifyPropertyChanged members
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
