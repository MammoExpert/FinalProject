﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MammoExpert.PatientServices.Worklist
{
    /// <summary>
    /// Предоставляет и задает значения для подключения к Dicom Worklist.
    /// </summary>
    public class WorklistSource
    {
        /// <summary>
        /// Получает или задает значение отображаемому имени
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// Получает или задает значение AE заголовку
        /// </summary>
        public string AETitle { get; set; }
        /// <summary>
        /// Получает или задает значение имени хоста (IP адреса).
        /// </summary>
        public string Host { get; set; }
        /// <summary>
        /// Получает или задает значение порта подключения.
        /// </summary>
        public string Port { get; set; }
        /// <summary>
        /// Получает или задает значение таймаута подключения
        /// </summary>
        public int Timeout { get; set; }
    }
}
