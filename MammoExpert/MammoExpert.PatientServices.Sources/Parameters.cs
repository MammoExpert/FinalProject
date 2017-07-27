namespace MammoExpert.PatientServices.Sources
{
    public class Parameters
    {
        public string DisplayedName { get; set; }
        public string Header { get; set; }
        public string Ip { get; set; }
        public string Port { get; set; }
        public string Timeout { get; set; }
        public string Driver { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public Parameters()
        {
            DisplayedName = string.Empty;
            Header = string.Empty;
            Ip = string.Empty;
            Port = string.Empty;
            Timeout = string.Empty;
            Driver = string.Empty;
            UserName = string.Empty;
            Password = string.Empty;
        }
    }
}
