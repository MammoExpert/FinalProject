using MammoExpert.PatientServices.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MammoExpert.PatientServices.Infrastructure
{
    public class NotificationConnectionMessenger : INotificationConnectionMessenger
    {
       
        public void ShowConnectionErrorMessage(Exception exeption)
        {
            MessageBox.Show(
                $"{exeption.Message}",
                "Ошибка подключения",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }

        public void ShowConnectionSuccess(string message)
        {
            MessageBox.Show(
                message,
                "Тест подключения",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
    }
}
