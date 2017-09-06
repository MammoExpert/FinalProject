using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MammoExpert.PatientServices.Sources
{
    public class Source
    {
        private static Dictionary<SourceType, Dictionary<string, string>> dic = new Dictionary<SourceType, Dictionary<string, string>>()
        {
            {SourceType.DataBase, new Dictionary<string, string>()
            {
                {"Driver", "" },
                {"Ip", ""},
                {"Port", ""},
                {"UserName", ""},
                {"Password", ""}
            } },
            {SourceType.Worklist, new Dictionary<string, string>()
            {
                {"Header", ""},
                {"Ip", ""},
                {"Port", ""},
                {"Timeout", ""}
            } }
        };

        public int Id { get; set; }
        public SourceType Type { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public string ConnectionString { get; set; }

        public Dictionary<string, string> Parameters { get; set; }

        public Source(SourceType type)
        {
            Type = type;
            Id = new Random().Next(0, 999);
            Description = string.Empty;
            Name = string.Empty;
            ConnectionString = string.Empty;
            Parameters = dic[type];
        }
    }
}
