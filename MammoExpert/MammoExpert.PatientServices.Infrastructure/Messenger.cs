using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MammoExpert.PatientServices.Infrastructure
{
    /// <summary>
    /// Статический класс для отображения сообщений и диалоговых окон
    /// </summary>
    public static class Messenger
    {
        #region Public Metods

        /// <summary>
        /// Возвращает сообщение об ошибке подключения
        /// </summary>
        /// <param name="exeption"></param>
        public static void ShowConnectionDbErrorMessage(Exception exeption)
        {
            MessageBox.Show(
                $"{exeption.Message}",
                "Ошибка подключения",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }

        /// <summary>
        /// Возвращает диалоговое окно для подтверждения удаления
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="postConfirmAction"></param>
        public static void ShowAskToDeleteMessage(string itemName, Action postConfirmAction)
        {
            var result = MessageBox.Show(
                "Вы уверены, что хотите удалить " + itemName + "?",
                "ВНИМАНИЕ!",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes) postConfirmAction();
        }

        /// <summary>
        /// Возвращает сообщание о добавлении нового пациента в базу
        /// </summary>
        public static void ShowPatientCreationMessage()
        {
            MessageBox.Show(
                "Пациент создан",
                "Подтверждение",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        public static void ShowConnectionDbSuccess(string message)
        {
            MessageBox.Show(
                message,
                "Тест подключения",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        public static void ShowNotFindFileMessage(Exception ex, string filePath)
        {
            // текст по умолчанию
            var errorMsg = "Произошла внутренняя ошибка";
            var errorHeader = "Ошибка";

            if (ex.InnerException is FileNotFoundException)
            {
                errorMsg = "Файл '" + filePath + "' не найден";
                errorHeader = "Ошибка при загрузке файла";
            }

            if (ex.InnerException is UnauthorizedAccessException)
            {
                errorMsg = "Доступ к файлу '" + filePath + "' запрещен";
                errorHeader = "Нет доступа";
            }

            if (ex.InnerException is FileLoadException)
            {
                errorMsg = "Не удалось загрузить файл '" + filePath;
                errorHeader = "Ошибка загрузки файла";
            }

            MessageBox.Show(errorMsg, errorHeader,
                MessageBoxButton.OK, MessageBoxImage.Error);

            Application.Current.Shutdown();
        }

        /// <summary>
        /// Возвращает сообщение об ошибке подключения
        /// </summary>
        /// <param name="exeption"></param>
        public static void ShowConnectionWorklistErrorMessage(Exception exeption)
        {
            MessageBox.Show(
                $"{exeption.Message}",
                "Ошибка подключения",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }

        public static void ShowConnectionWorklistSuccess(string message)
        {
            MessageBox.Show(
                message,
                "Тест подключения",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        #endregion // Public Metods
    }
}
