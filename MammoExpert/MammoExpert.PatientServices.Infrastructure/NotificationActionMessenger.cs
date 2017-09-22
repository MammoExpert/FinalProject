using MammoExpert.PatientServices.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MammoExpert.PatientServices.Infrastructure
{
    public class NotificationActionMessenger : INotificationActionMessenger
    {
        public const string DefaultErrorMsg = "Произошла внутренняя ошибка";
        public const string DefaultErrorHeader = "Ошибка";
        public const string FilenotfoundExErrMsg = "Файл '(0)' не найден";
        public const string UnauthorizedAccessУккЬып = "Нет прав на доступ к файлу '(0)'";
        public const string FileLoadErrMsg = "Не удалось загрузить файл '(0)'";

        public void ShowAskToDeleteMessage(string itemName, Action postConfirmAction)
        {
            var result = MessageBox.Show(
                "Вы уверены, что хотите удалить " + itemName + "?",
                "ВНИМАНИЕ!",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes) postConfirmAction();
        }

        public void ShowFileErrorMessage(Exception ex, string filePath)
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

                errorMsg = string.Format(UnauthorizedAccessУккЬып, filePath);
                errorHeader = "Нет доступа";
            }

            if (ex.InnerException is FileLoadException)
            {
                errorMsg = string.Format(FileLoadErrMsg, filePath);
                errorHeader = "Ошибка при загрузке";
            }

            MessageBox.Show(errorMsg, errorHeader,
                MessageBoxButton.OK, MessageBoxImage.Error);

            Application.Current.Shutdown();
        }
    }
}
