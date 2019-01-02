﻿using System;
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
