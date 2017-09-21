using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MammoExpert.PatientServices.Core
{
    /// <summary>
    /// Предоставляет методы уведовмления подключения к источнику данных
    /// </summary>
    public interface INotificationConnectionMessenger
    {
        void ShowConnectionErrorMessage(Exception exeption);
        void ShowConnectionSuccess(string message);
    }
}
