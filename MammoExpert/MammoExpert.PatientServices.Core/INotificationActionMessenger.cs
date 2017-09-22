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
        void ShowAskToDeleteMessage(string itemName, Action postConfirmAction);
        void ShowFileErrorMessage(Exception ex, string filePath);
    }
}
