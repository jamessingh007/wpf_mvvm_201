﻿using System.Collections.ObjectModel;

namespace WpfApp1.Common
{
    public static class Courses
    {
        public static ObservableCollection<string> Course = new ObservableCollection<string>() { "Development", "Testing", "Cloud" };
        public static TrainingContext _dbcontext = new TrainingContext();

    }
}
