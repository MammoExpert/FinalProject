using System.Runtime.Serialization;

namespace MammoExpert.PatientServices.Sources
{
    [DataContract]
    public class Source
    {
        #region Properties

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public SourceType Type { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public Parameters Parameters { get; set; }

        #endregion // Properties

        #region Constructors

        public Source()
        {
            Name = string.Empty;
            Description = string.Empty;
            Parameters = new Parameters();
        }

        public Source(string name, SourceType type, string description, Parameters parameters)
        {
            Name = name;
            Type = type;
            Description = description;
            Parameters = parameters;
        }

        #endregion // Constructors
    }
}
