using System;
using System.Windows;
using WpfApp1.ViewModels;

namespace WpfApp1.Views
{
    /// <summary>
    /// Interaction logic for AddParticipantView.xaml
    /// </summary>
    public partial class AddParticipantView : Window
    {
        public AddParticipantView()
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
                cbxCourseRegistered.ItemsSource = ((ParticipantViewModel)this.DataContext).StreamCollection;
            }
            catch (Exception ex)
            {
                exObj.ShowExMsg(ex);
            }

        }
    }
}
