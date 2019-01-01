using System.Windows;
using WpfApp1.ViewModels;

namespace WpfApp1.Views
{
    /// <summary>
    /// Interaction logic for SearchParticipant.xaml
    /// </summary>
    public partial class SearchParticipant : Window
    {
        public SearchParticipant()
        {
            InitializeComponent();
            this.DataContext = new ParticipantViewModel();
            //cbxBatchID.ItemsSource = ((ParticipantViewModel)this.DataContext).BatchIDCollection;
            //cbxCourseRegistered.ItemsSource = ((ParticipantViewModel)this.DataContext).StreamCollection;
        }

    }
}
