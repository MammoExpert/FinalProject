using System;
using System.Runtime.Serialization;

namespace MammoExpert.PatientServices.Sources
{
    [DataContract]
    public class Source
    {
        #region Properties

        [DataMember]
        public string ConectionString { get; set; }

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
            ConectionString = string.Empty;
            Name = string.Empty;
            Description = string.Empty;
            Parameters = new Parameters();
        }

        public Source(SourceType type)
        {
            ConectionString = string.Empty;
            Name = string.Empty;
            Type = type;
            Description = string.Empty;
            Parameters = new Parameters();
        }

        #endregion // Constructors
    }
}
