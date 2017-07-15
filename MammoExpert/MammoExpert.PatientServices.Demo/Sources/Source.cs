using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MammoExpert.PatientServices.Demo.Sources
{
    public class Source
    {
        public enum Types
        {
            DataBase,
            WorkList
        };

        public string Name { get; set; }

        public Types Type { get; set; }

        public string Description { get; set; }

        public Source(string name, Types typeName, string description)
        {
            Name = name;
            Type = typeName;
            Description = description;
        }
        public Source(string name, Types typeName)
        {
            Name = name;
            Type = typeName;
            Description = string.Empty;
        }

    }
}
