using System;
using System.Windows;
using WpfApp1.ViewModels;

namespace WpfApp1.Views
{
    /// <summary>
    /// Interaction logic for SearchFacultyView.xaml
    /// </summary>
    public partial class SearchFacultyView : Window
    {
        public SearchFacultyView()
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
                this.DataContext = new FacultyViewModel();
            }
            catch (Exception ex)
            {
                exObj.ShowExMsg(ex);
            }

        }
    }
}
