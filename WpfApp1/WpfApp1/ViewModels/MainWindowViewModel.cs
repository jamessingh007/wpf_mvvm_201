using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.Views;

namespace WpfApp1.ViewModels
{
    class MainWindowViewModel
    {
        /// <summary>
        /// show add faculty view
        /// </summary>
        private ICommand _ShowAddFaculty;
        public ICommand ShowAddFacultyCommand
        {
            get
            {
                if (_ShowAddFaculty == null)
                    _ShowAddFaculty = new RelayCommand(ShowAddFaculty);
                return _ShowAddFaculty;
            }
        }

        private void ShowAddFaculty()
        {
            AddFacultyView obj = new AddFacultyView();
            obj.Show();
        }

        /// <summary>
        /// show search faculty view
        /// </summary>
        private ICommand _ShowSearchFaculty;
        public ICommand ShowSearchFacultyCommand
        {
            get
            {
                if (_ShowSearchFaculty == null)
                    _ShowSearchFaculty = new RelayCommand(ShowSearchFaculty);
                return _ShowSearchFaculty;
            }
        }

        private void ShowSearchFaculty()
        {
            SearchFacultyView obj = new SearchFacultyView();
            obj.Show();
        }

        /// <summary>
        /// show add batch view
        /// </summary>
        private ICommand _ShowAddBatch;
        public ICommand ShowAddBatchCommand
        {
            get
            {
                if (_ShowAddBatch == null)
                    _ShowAddBatch = new RelayCommand(ShowAddBatch);
                return _ShowAddBatch;
            }
        }

        private void ShowAddBatch()
        {
            AddBatchView obj = new AddBatchView();
            obj.Show();
        }

        /// <summary>
        /// show search batch view
        /// </summary>
        private ICommand _ShowSearchBatch;
        public ICommand ShowSearchBatchCommand
        {
            get
            {
                if (_ShowSearchBatch == null)
                    _ShowSearchBatch = new RelayCommand(ShowSearchBatch);
                return _ShowSearchBatch;
            }
        }

        private void ShowSearchBatch()
        {
            SearchBatchView obj = new SearchBatchView();
            obj.Show();
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
        /// show search participant view
        /// </summary>
        private ICommand _ShowSearchParticipant;
        public ICommand ShowSearchParticipantCommand
        {
            get
            {
                if (_ShowSearchParticipant == null)
                    _ShowSearchParticipant = new RelayCommand(ShowSearchParticipant);
                return _ShowSearchParticipant;
            }
        }

        private void ShowSearchParticipant()
        {
            SearchParticipantView obj = new SearchParticipantView();
            obj.Show();
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
