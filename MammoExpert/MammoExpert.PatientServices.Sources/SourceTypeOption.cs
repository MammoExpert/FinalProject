using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MammoExpert.PatientServices.Sources
{
    // класс, предназначенный для описания типа источника
    public class SourceTypeOption
    {
        public SourceType Type { get; set; }
        public string Description { get; protected set; }
        internal Dictionary<SourceType, string> DescriptionDictionary = new Dictionary<SourceType, string>()
        {
            {SourceType.DataBase, "База данных"},
            {SourceType.Worklist, "Рабочий список" }
        };

        public SourceTypeOption(SourceType type)
        {
            Type = type;
            Description = DescriptionDictionary[type];
        }
    }
}
