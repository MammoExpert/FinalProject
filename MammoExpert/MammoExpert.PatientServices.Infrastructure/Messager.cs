﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MammoExpert.PatientServices.Infrastructure
{
    public static class Messager
    {
        /// <summary>
        /// Возвращает сообщение об ошибке подключения
        /// </summary>
        /// <param name="exeption"></param>
        public static void ShowConnectionErrorMessage(Exception exeption)
        {
            MessageBox.Show(
                exeption.Message,
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

        public static void ShowConnectionSuccess(string message)
        {
            MessageBox.Show(
                message,
                "Тест подключения",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        public static void ShowNotFindFileMessage(string filePath)
        {
            MessageBox.Show("Файл '" + filePath + "' не найден", "Ошибка при загрузке файла",
                MessageBoxButton.OK, MessageBoxImage.Error);
            Environment.Exit(0);
        }
    }
}
