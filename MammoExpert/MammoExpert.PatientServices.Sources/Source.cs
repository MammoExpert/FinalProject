using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MammoExpert.PatientServices.Sources
{
    public class Source
    {
        public int Id { get; set; }
        public SourceType Type { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string ConnectionString { get; set; }

        public string Driver { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string Header { get; set; }
        public string Ip { get; set; }
        public string Port { get; set; }
        public string Timeout { get; set; }


        public Source(SourceType type)
        {
            Type = type;
            Id = new Random().Next(0, 999);
        }
    }
}
