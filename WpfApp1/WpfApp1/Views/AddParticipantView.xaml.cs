﻿using System.Windows;
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
            this.DataContext = new ParticipantViewModel();
            cbxCourseRegistered.ItemsSource = ((ParticipantViewModel)this.DataContext).StreamCollection;
            //cbxBatchID.ItemsSource = ((ParticipantViewModel)this.DataContext).BatchIDCollection;
        }
    }
}
