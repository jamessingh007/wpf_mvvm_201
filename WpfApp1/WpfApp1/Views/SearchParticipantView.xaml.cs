using System;
using System.Windows;
using WpfApp1.ViewModels;

namespace WpfApp1.Views
{
    /// <summary>
    /// Interaction logic for SearchParticipant.xaml
    /// </summary>
    public partial class SearchParticipantView : Window
    {
        public SearchParticipantView()
        {
            InitializeComponent();
            SetDataContext();
        }
        /// <summary>
        /// 
        /// </summary>
        internal void SetDataContext()
        {
            ExceptionHandling exObj = new ExceptionHandling();
            try
            {
                this.DataContext = new ParticipantViewModel();
            }
            catch (Exception ex)
            {
                exObj.ShowExMsg(ex);
            }

        }

    }
}
