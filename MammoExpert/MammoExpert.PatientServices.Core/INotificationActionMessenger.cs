using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MammoExpert.PatientServices.Core
{
    public interface INotificationActionMessenger
    {
        MessageBoxResult ShowAskToDeleteMessage(string itemName);
        void ShowPatientCreationMessage();
        void ShowNotFindFileMessage(Exception ex, string filePath);
    }
}
