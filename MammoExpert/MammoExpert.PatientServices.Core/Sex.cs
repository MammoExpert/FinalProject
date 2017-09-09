using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;

namespace MammoExpert.PatientServices.Core
{
    /// <summary>
    /// Представляет перечисления пола пациента.
    /// </summary>
    public enum Sex
    {
        Male = 0,
        Female = 1
    };

    /// <summary>
    /// Предоставляет метод конвертации из <see cref="string"/> в <see cref="Enum"/>.
    /// </summary>
    public class ConvertorToEnum
    {
        #region Field

        private static Dictionary<string, Sex> sexEnumDictionary = new Dictionary<string, Sex>()
        {
            { "m", Sex.Male },
            { "f", Sex.Female }
        };

        #endregion //Field

        #region Public Static Metods

        public static Sex GetEnum(string stringSex)
        {
            return sexEnumDictionary[stringSex];
        }

        #endregion // Public Static Metods
    }
}