namespace MammoExpert.PatientServices.Sources
{
    public class Parameters
    {
        #region Properties

        public string Header { get; set; }
        public string Ip { get; set; }
        public string Port { get; set; }
        public string Timeout { get; set; }
        public string Driver { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        #endregion // Properties

        #region Constructor

        public Parameters()
        {
            Header = string.Empty;
            Ip = string.Empty;
            Port = string.Empty;
            Timeout = string.Empty;
            Driver = string.Empty;
            UserName = string.Empty;
            Password = string.Empty;
        }

        #endregion // Constructor
    }
}
