using MammoExpert.PatientServices.DB;
using MammoExpert.PatientServices.Sources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MammoExpert.PatientServices.Sources
{
    /// <summary>
    /// Вспомогательный класс для преобразования типа Source в специальные типы DbSource и WlSource
    /// </summary>
    public static class SourceSerializer
    {
        /// <summary>
        /// Преобразует тип <see cref="DbSource"/> в тип <see cref="Source"/>
        /// </summary>
        public static Source DbSerialize(DbSource dbSource)
        {
            var source = new Source(SourceTypeEnum.DataBase);
            source.Parameters["Driver"] = dbSource.Provider;
            source.Parameters["Port"] = dbSource.Port;
            source.Parameters["Ip"] = dbSource.Host;
            source.Parameters["Name"] = dbSource.DataBase;
            source.Parameters["UserName"] = dbSource.UserId;
            source.Parameters["Password"] = dbSource.Password;
            return source;
        }

        /// <summary>
        /// Преобразует тип <see cref="Source"/> в тип <see cref="DbSource"/>
        /// </summary>
        public static DbSource DbDeserialize(Source source)
        {
            var dbSource = new DbSource();
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
