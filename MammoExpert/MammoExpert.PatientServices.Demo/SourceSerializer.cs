using MammoExpert.PatientServices.DB;
using MammoExpert.PatientServices.Sources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MammoExpert.PatientServices.Demo
{
    public static class SourceSerializer
    {
        public static Source DbSerialize(DbSource dbSource)
        {
            Source source = new Source(SourceType.DataBase);
            source.Parameters["Driver"] = dbSource.Provider;
            source.Parameters["Port"] = dbSource.Port;
            source.Parameters["Ip"] = dbSource.Host;
            source.Parameters["Name"] = dbSource.DataBase;
            source.Parameters["UserName"] = dbSource.UserId;
            source.Parameters["Password"] = dbSource.Password;
            return source;
        }

        public static DbSource DbDeserialize(Source source)
        {
            DbSource dbSource = new DbSource();
            dbSource.Provider = source.Parameters["Driver"];
            dbSource.Port = source.Parameters["Port"];
            dbSource.Host = source.Parameters["Ip"];
            dbSource.DataBase = source.Name;
            dbSource.UserId = source.Parameters["UserName"];
            dbSource.Password = source.Parameters["Password"];
            return dbSource;
        }
    }
}
