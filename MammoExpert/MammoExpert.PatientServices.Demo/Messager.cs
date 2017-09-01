using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MammoExpert.PatientServices.Demo
{
    public static class Messager
    {
        public static void ShowConnectionErrorMessage(Exception exeption)
        {
            MessageBox.Show(
                exeption.Message,
                "Ошибка подключения",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }

        public static void ShowAskToDeleteMessage(string itemName, Action postConfirmAction)
        {
            var result = MessageBox.Show(
                "Вы уверены, что хотите удалить " + itemName + "?",
                "ВНИМАНИЕ!",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes) postConfirmAction();
        }
    }
}
