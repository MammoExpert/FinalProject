using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MammoExpert.PatientServices.Sources
{
    /// <summary>
    /// Описывает Enum-значение типа источника в виде строки
    /// </summary>
    public class SourceTypeOption
    {
        public SourceTypeEnum TypeEnum { get; set; }
        public string Description { get; protected set; }
        internal Dictionary<SourceTypeEnum, string> DescriptionDictionary = new Dictionary<SourceTypeEnum, string>()
        {
            {SourceTypeEnum.DataBase, "База данных"},
            {SourceTypeEnum.Worklist, "Рабочий список" }
        };

        public SourceTypeOption(SourceTypeEnum typeEnum)
        {
            TypeEnum = typeEnum;
            Description = DescriptionDictionary[typeEnum];
        }
    }
}
