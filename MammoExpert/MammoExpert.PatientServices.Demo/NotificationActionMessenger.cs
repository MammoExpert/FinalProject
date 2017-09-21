using MammoExpert.PatientServices.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MammoExpert.PatientServices.Demo
{
    public class NotificationActionMessenger : INotificationActionMessenger
    {
        public const string DefaultErrorMsg = "Произошла внутренняя ошибка";
        public const string DefaultErrorHeader = "Ошибка";
        public const string FilenotfoundExErrMsg = "Файл '(0)' не найден)";

        public MessageBoxResult ShowAskToDeleteMessage(string itemName)
        {
            var result = MessageBox.Show(
                "Вы уверены, что хотите удалить " + itemName + "?",
                "ВНИМАНИЕ!",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            return result;
        }

        public void ShowNotFindFileMessage(Exception ex, string filePath)
        {
            var errorMsg = DefaultErrorMsg;
            var errorHeader = DefaultErrorHeader;

            if (ex.InnerException is FileNotFoundException)
            {
                errorMsg = string.Format(FilenotfoundExErrMsg, filePath);
                errorHeader = "Ошибка при загрузке файла";
            }

            if (ex.InnerException is UnauthorizedAccessException)
            {

            }

            if (ex.InnerException is FileLoadException)
            {

            }

            MessageBox.Show(errorMsg, errorHeader,
                MessageBoxButton.OK, MessageBoxImage.Error);

            Application.Current.Shutdown();
        }

        public void ShowPatientCreationMessage()
        {
            MessageBox.Show(
                "Пациент создан",
                "Подтверждение",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
    }
}
