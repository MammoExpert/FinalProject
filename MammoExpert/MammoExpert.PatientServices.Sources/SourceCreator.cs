using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MammoExpert.PatientServices.Sources
{
    public class SourceCreator
    {
        private static Dictionary<SourceType, Dictionary<string, string>> dic = new Dictionary<SourceType, Dictionary<string, string>>()
        {
            {SourceType.DataBase, new Dictionary<string, string>()
            {
                {"Driver", "" },
                {"Ip", ""},
                {"Port", ""},
                {"Name", ""},
                {"UserName", ""},
                {"Password", ""}
            } },
            {SourceType.Worklist, new Dictionary<string, string>()
            {
                {"Name", ""},
                {"Header", ""},
                {"Ip", ""},
                {"Port", ""},
                {"Timeout", ""}
            } }
        };

        public static Source Create(SourceType type)
        {
            return new Source(type) { Parameters = dic[type] };
        }
    }

}
