using System.ComponentModel;
using System.Linq;

namespace MammoExpert.PatientServices.Sources
{
    // Описывает варианты типов источника
    public enum SourceType
    {
        [Description("База данных")]
        DataBase,
        [Description("Рабочий список")]
        Worklist
    }

    // Метод расширения для получения описаний идентификаторов перечисляемого типа SourceType
    public static class EnumExtensions
    {
        static public string Description(this SourceType value)
        {
            var attribute = value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(false)
                .First() as DescriptionAttribute;

            return attribute.Description;
        }
    }
}
