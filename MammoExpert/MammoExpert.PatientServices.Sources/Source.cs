using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MammoExpert.PatientServices.Sources
{
    /// <summary>
    /// Модель источника данных
    /// </summary>
    public class Source : IEquatable<Source>
    {
        #region Dictionaries

        /// <summary>
        /// Хранит перечень параметров для определенного типа источника
        /// </summary>
        private static readonly Dictionary<SourceTypeEnum, Dictionary<string, string>> ParametersDictionary = new Dictionary<SourceTypeEnum, Dictionary<string, string>>()
        {
            {SourceTypeEnum.DataBase, new Dictionary<string, string>()
            {
                {"Driver", "" },
                {"Ip", ""},
                {"Port", ""},
                {"UserName", ""},
                {"Password", ""}
            } },
            {SourceTypeEnum.Worklist, new Dictionary<string, string>()
            {
                {"Header", ""},
                {"IdNumber", ""},
                {"Ip", ""},
                {"Port", ""},
                {"Timeout", ""}
            } }
        };

        #endregion // Dictionaries

        #region Constructor

        public Source(SourceTypeEnum typeEnum)
        {
            TypeEnum = typeEnum;
            Description = string.Empty;
            Name = string.Empty;
            Parameters = ParametersDictionary[typeEnum];
        }

        #endregion // Constructor

        #region Properties
        /// <summary>
        /// Получает или задает значение типа источника
        /// </summary>
        public SourceTypeEnum TypeEnum { get; set; }
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

        public bool Equals(Source other)
        {
            if (TypeEnum == SourceTypeEnum.DataBase && other.TypeEnum == SourceTypeEnum.DataBase)
            {
                return Description == other.Description
                       && Name == other.Name
                       && Parameters["Driver"] == other.Parameters["Driver"]
                       && Parameters["Port"] == other.Parameters["Port"]
                       && Parameters["Ip"] == other.Parameters["Ip"]
                       && Parameters["UserName"] == other.Parameters["UserName"]
                       && Parameters["Password"] == other.Parameters["Password"];
            }

            if (TypeEnum == SourceTypeEnum.Worklist && other.TypeEnum == SourceTypeEnum.Worklist)
            {
                return Description == other.Description
                       && Name == other.Name
                       && Parameters["Header"] == other.Parameters["Header"]
                       && Parameters["Port"] == other.Parameters["Port"]
                       && Parameters["Ip"] == other.Parameters["Ip"]
                       && Parameters["Timeout"] == other.Parameters["Timeout"];
            }

            return false;
        }
    }
}
