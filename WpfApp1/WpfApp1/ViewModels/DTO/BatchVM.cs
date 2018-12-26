using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WpfApp1.ViewModels
{
    class Batch : INotifyPropertyChanged
    {
        public WpfApp1.BATCH objBatch;
        private string _searchKeyword;

        public Batch()
        {
            objBatch = new BATCH();
        }

        public int BatchID
        {
            get
            {
                return objBatch.BatchID;
            }
            set
            {
                objBatch.BatchID = value;
            }
        }
        
        public Nullable<System.DateTime> BatchStartDate
        {
            get
            {
                
                var _bsd = objBatch.BatchStartDate;
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
                    objBatch.BatchStartDate = DateTime.Parse(_bsd).Date;
                    OnPropertyChanged("BatchStartDate");
                }
            }
        }

        public Nullable<System.DateTime> BatchEndDate
        {
            get
            {
                var _bed = objBatch.BatchEndDate;
                Nullable<DateTime> bed=null;
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
                    objBatch.BatchEndDate = DateTime.Parse(_bed).Date;
                    OnPropertyChanged("BatchEndDate");
                }
            }
        }

        public String Stream
        {
            get
            {
                return objBatch.Stream;
            }
            set
            {
                objBatch.Stream = value;
                OnPropertyChanged("Stream");
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
