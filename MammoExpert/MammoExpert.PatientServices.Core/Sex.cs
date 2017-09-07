using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;

namespace MammoExpert.PatientServices.Core
{
    //перечисление для выбора пола пациента
    public enum Sex { Male, Female };

    public class ConvertorToEnum
    {
        public static Sex GetEnum(string stringSex)
        {
            Sex sex = Sex.Male;
            switch (stringSex)
            {
                case "f":
                    sex = Sex.Female;
                    break;
                case "m":
                    sex = Sex.Male;
                    break;
            }
            return sex;
        }
    }
}