using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class DBConnectionSection : ConfigurationSection
    {
        //Создание атрибута «Только удаленный доступ»
        [ConfigurationProperty("remoteOnly", DefaultValue = "false", IsRequired = false)]
        public Boolean RemoteOmly
        {
            get
            {
                return (Boolean)this["remoteOnly"];
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
                return (String)this["connectionString"];
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
                return (String)this["providerName"];
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
                return (String)this["name"];
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
                return (String)this["dataSource"];
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
                return (String)this["initialCatalog"];
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
                return (String)this["userID"];
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
                return (String)this["password"];
            }
            set
            {
                this["password"] = value;
            }
        }

        [ConfigurationProperty("connectTimeout", DefaultValue = "1000", IsRequired = false)]
        [IntegerValidator(ExcludeRange = false, MaxValue = 24, MinValue = 6)]
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
        public Boolean IntegratedSecurity
        {
            get
            {
                return (Boolean)this["integratedSecurity"];
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
                return (String)this["name"];
            }
            set
            {
                this["name"] = value;
            }
        }
    }
}
