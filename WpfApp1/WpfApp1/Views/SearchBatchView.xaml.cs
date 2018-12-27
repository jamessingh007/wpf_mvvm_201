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
            this.DataContext = new BatchViewModel();
        }
    }
}
