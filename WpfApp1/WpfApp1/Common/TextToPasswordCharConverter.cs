using System;
using System.Globalization;
using System.Windows.Data;
using WpfApp1.ViewModels.DTO;

namespace WpfApp1.Common
{
    public class TextToPasswordCharConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new String('*', value?.ToString().Length ?? 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (true)
            { }
            LoginVM.EnteredKey = value.ToString().Substring(value.ToString().Length - 1);
                return new String('*', value?.ToString().Length ?? 0);
            
        }
    }
}
