using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;

namespace MammoExpert.PatientServices.Core
{
    /// <summary>
    /// ������������ ������������ ���� ��������.
    /// </summary>
    public enum Sex
    {
        Male = 0,
        Female = 1
    };

    /// <summary>
    /// ������������� ����� ����������� �� <see cref="string"/> � <see cref="Enum"/>.
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