using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MammoExpert.PatientServices.Sources;

namespace MammoExpert.PatientServices.Tests.Sources.FakeData
{
    public class FakeJsonCollection
    {
        public List<Source> Collection = new List<Source>();
        public FakeJsonCollection()
        {
            Collection.Add(new Source(SourceTypeEnum.DataBase)
            {
                Description = "Desc",
                Id = 20,
                Name = "Name",
                Parameters = new Dictionary<string, string>()
                {
                    {"Driver", "Driver" },
                    {"Ip", "127"},
                    {"Port", "8080"},
                    {"UserName", "Ivan"},
                    {"Password", "123"}
                }
            });

            Collection.Add(new Source(SourceTypeEnum.Worklist)
            {
                Description = "Desc",
                Id = 12,
                Name = "Name",
                Parameters = new Dictionary<string, string>()
                {
                    {"Header", "Header"},
                    {"Ip", "127"},
                    {"Port", "8080"},
                    {"Timeout", "2000"}
                }
            });
        }
    }
}
