using System.Configuration;

namespace MammoExpert.PatientServices.DB
{
    public class DBConnectionSection : ConfigurationSection
    {
        //Создание атрибута «Только удаленный доступ»
        [ConfigurationProperty("remoteOnly", DefaultValue = "false", IsRequired = false)]
        public bool RemoteOnly
        {
            get
            {
                return (bool)this["remoteOnly"];
            }
            set
            {
                this["remoteOnly"] = value;
            }
        }

        //создание элемента "ConnectionString"
        [ConfigurationProperty("connectionString")]
        public string ConnectionString
        {
            get
            {
                return (string)this["connectionString"];
            }
            set
            {
                this["connectionString"] = value;
            }
        }

        //создание элемента "ProviderName"
        [ConfigurationProperty("providerName")]
        public string ProviderName
        {
            get
            {
                return (string)this["providerName"];
            }
            set
            {
                this["providerName"] = value;
            }
        }
    }

    //Определяем элемент "ConnectionString"
    public class ConnectionString : ConfigurationElement
    {
        [ConfigurationProperty("name", DefaultValue = "DefaultConnectionString", IsRequired = false)]
        [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\", MinLength = 1, MaxLength = 60)]
        public string Name
        {
            get
            {
                return (string)this["name"];
            }
            set
            {
                this["name"] = value;
            }
        }

        [ConfigurationProperty("dataSource", DefaultValue = "(localdb)\v11.0", IsRequired = false)]
        [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;", MinLength = 1, MaxLength = 60)]
        public string DataSource
        {
            get
            {
                return (string)this["dataSource"];
            }
            set
            {
                this["dataSource"] = value;
            }
        }

        [ConfigurationProperty("initialCatalog", DefaultValue = "PatientServices", IsRequired = false)]
        [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\", MinLength = 1, MaxLength = 60)]
        public string InitialCatalog
        {
            get
            {
                return (string)this["initialCatalog"];
            }
            set
            {
                this["initialCatalog"] = value;
            }
        }

        [ConfigurationProperty("userID", DefaultValue = "TestUser", IsRequired = false)]
        [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\", MinLength = 1, MaxLength = 60)]
        public string UserID
        {
            get
            {
                return (string)this["userID"];
            }
            set
            {
                this["userID"] = value;
            }
        }

        [ConfigurationProperty("password", DefaultValue = "12345", IsRequired = false)]
        [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\", MinLength = 1, MaxLength = 60)]
        public string Password
        {
            get
            {
                return (string)this["password"];
            }
            set
            {
                this["password"] = value;
            }
        }

        [ConfigurationProperty("connectTimeout", DefaultValue = "2000", IsRequired = false)]
        [IntegerValidator(ExcludeRange = false, MaxValue = 3000, MinValue = 1000)]
        public int ConnectTimeout
        {
            get
            {
                return (int)this["connectTimeout"];
            }
            set
            {
                this["connectTimeout"] = value;
            }
        }

        [ConfigurationProperty("integratedSecurity", DefaultValue = "true", IsRequired = false)]
        public bool IntegratedSecurity
        {
            get
            {
                return (bool)this["integratedSecurity"];
            }
            set
            {
                this["integratedSecurity"] = value;
            }
        }
    }

    //Определяем элемент "ProviderName"
    public class ProviderName : ConfigurationElement
    {
        [ConfigurationProperty("name", DefaultValue = "System.Data.SqlClient", IsRequired = false)]
        [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\", MinLength = 1, MaxLength = 60)]
        public string Name
        {
            get
            {
                return (string)this["name"];
            }
            set
            {
                this["name"] = value;
            }
        }
    }
}
