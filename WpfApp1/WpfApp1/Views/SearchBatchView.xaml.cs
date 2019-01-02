using System;
using System.Windows;
using WpfApp1.ViewModels;
namespace WpfApp1.Views
{
    /// <summary>
    /// Interaction logic for SearchBatchView.xaml
    /// </summary>
    public partial class SearchBatchView : Window
    {
        public SearchBatchView()
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
            }
            catch (Exception ex)
            {
                exObj.ShowExMsg(ex);
            }

        }
    }
}
