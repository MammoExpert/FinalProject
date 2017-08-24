using System.Runtime.Serialization;

namespace MammoExpert.PatientServices.Sources
{
    [DataContract]
    public class Source
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public SourceType Type { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public Parameters Parameters { get; set; }

        public Source(string name, SourceType typeName, string description)
        {
            Name = name;
            Type = typeName;
            Description = description;
            Parameters = new Parameters();
        }

        public Source()
        {
            Name = string.Empty;
            Description = string.Empty;
            Parameters = new Parameters();
        }
    }
}
