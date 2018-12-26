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
        internal void ShowExMsg(Exception Exception)
        {
            if (Exception != null)
            {
                MessageBox.Show(Exception.InnerException.ToString(), "Exception", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Operation was not successful","Error", MessageBoxButton.OK);
            }

        }
    }
}
