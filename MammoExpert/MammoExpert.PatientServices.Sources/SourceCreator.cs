using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MammoExpert.PatientServices.Sources
{
    public class SourceCreator
    {
        private static int _counter;

        private static Dictionary<SourceType, Dictionary<string, string>> dic = new Dictionary<SourceType, Dictionary<string, string>>()
        {
            {SourceType.DataBase, new Dictionary<string, string>()
            {
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
            var result = new Source(type);
            result.Id = System.Threading.Interlocked.Increment(ref _counter);
            result.Parameters = dic[type];
            return result;
        }
    }

}
