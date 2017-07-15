using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MammoExpert.PatientServices.Demo.Helpers
{
    public class WindowCloser
    {
        public static void CloseWindow(Window window)
        {
            Application.Current.Dispatcher.Invoke(() => { window?.Close(); });
        }
    }
}
