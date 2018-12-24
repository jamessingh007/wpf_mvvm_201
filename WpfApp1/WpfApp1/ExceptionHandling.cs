using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    class ExceptionHandling
    {
        internal void ShowExMsg(Exception innerException)
        {
            MessageBox.Show(innerException.ToString(), "Exception", MessageBoxButton.OK);
        }
    }
}
