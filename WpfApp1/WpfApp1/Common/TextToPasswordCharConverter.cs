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
            if (value!= null && value.ToString().Length > 0)
            {
                return new String('*', value?.ToString().Length ?? 0);
            }
            else
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.ToString().Length > 0)
            {
                LoginVM.EnteredKey = value.ToString().Substring(value.ToString().Length - 1);
                return new String('*', value?.ToString().Length ?? 0);
            }
            else
            {
                LoginVM.EnteredKey = "";
                return null;
            }
        }
    }
}
