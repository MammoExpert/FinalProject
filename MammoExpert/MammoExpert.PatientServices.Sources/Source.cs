using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MammoExpert.PatientServices.Sources
{
    public class Source
    {
        public int Id { get; set; }

        public string ConectionString { get; set; }

        public SourceType Type { get; set; }

        public string Description { get; set; }

        public Dictionary<string, string> Parameters { get; set; }

        public Source(SourceType type)
        {
            Type = type;
            Id = new Random().Next(0, 999);
        }
    }

}
