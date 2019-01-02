using System;
using System.Windows;
using WpfApp1.ViewModels;

namespace WpfApp1.Views
{
    /// <summary>
    /// Interaction logic for AddBatchView.xaml
    /// </summary>
    public partial class AddBatchView : Window
    {
        public AddBatchView()
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
                this.DataContext = new BatchViewModel();
                cbxStream.ItemsSource = ((BatchViewModel)this.DataContext).StreamCollection;
                cbxFacultyID.ItemsSource = ((BatchViewModel)this.DataContext).FacultyIDCollection;
            }
            catch (Exception ex)
            {
                exObj.ShowExMsg(ex);
            }

        }
    }
}
