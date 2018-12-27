using System.Windows;
using WpfApp1.ViewModels;

namespace WpfApp1.Views
{
    /// <summary>
    /// Interaction logic for AddFacultyView.xaml
    /// </summary>
    public partial class AddFacultyView : Window
    {
        public AddFacultyView()
        {
            InitializeComponent();
            this.DataContext = new FacultyViewModel();

        }
    }
}
