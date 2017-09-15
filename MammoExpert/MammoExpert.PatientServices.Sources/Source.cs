using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MammoExpert.PatientServices.Sources
{
    /// <summary>
    /// Модель источника данных
    /// </summary>
    public class Source
    {
        #region Dictionaries

        /// <summary>
        /// Хранит перечень параметров для определенного типа источника
        /// </summary>
        private static readonly Dictionary<SourceType, Dictionary<string, string>> ParametersDictionary = new Dictionary<SourceType, Dictionary<string, string>>()
        {
            {SourceType.DataBase, new Dictionary<string, string>()
            {
                {"Driver", "" },
                {"Ip", ""},
                {"Port", ""},
                {"UserName", ""},
                {"Password", ""}
            } },
            {SourceType.Worklist, new Dictionary<string, string>()
            {
                {"Header", ""},
                {"Ip", ""},
                {"Port", ""},
                {"Timeout", ""}
            } }
        };

        #endregion // Dictionaries

        #region Constructor

        public Source(SourceType type)
        {
            Type = type;
            Id = new Random().Next(0, 999);
            Description = string.Empty;
            Name = string.Empty;
            Parameters = ParametersDictionary[type];
        }

        #endregion // Constructor

        #region Properties

        /// <summary>
        /// Получает или задает значение Id источника
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Получает или задает значение типа источника
        /// </summary>
        public SourceType Type { get; set; }
        /// <summary>
        /// Получает или задает значение описания источника
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Получает или задает значение имени источника
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Получает или задает перечень параметров источника
        /// </summary>
        public Dictionary<string, string> Parameters { get; set; }

        #endregion // Constructor

    }
}
