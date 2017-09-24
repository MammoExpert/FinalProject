using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MammoExpert.PatientServices.DB
{
    /// <summary>
    /// Предоставляет и задает значения для подключения к базе данных.
    /// </summary>
    public class DbSource : IEquatable<DbSource>
    {
        #region Proreties
        /// <summary>
        /// Получает или задает описание провайдера.
        /// </summary>
        public string Provider { get; set; }

        /// <summary>
        /// Получает или задает значение имени хоста (IP адреса).
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Получает или задает значение порта подключения.
        /// </summary>
        public string Port { get; set; }

        /// <summary>
        /// Получает или задает значение названия базы данных.
        /// </summary>
        public string DataBase { get; set; }

        /// <summary>
        /// Получает или задает значение имени пользователя.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Получает или задает значение пароля.
        /// </summary>
        public string Password { get; set; }

        #endregion // Properties

        public bool Equals(DbSource other)
        {
            return Provider == other.Provider
                   && Password == other.Password
                   && Port == other.Port
                   && Host == other.Host
                   && DataBase == other.DataBase
                   && UserId == other.UserId;
        }
    }
}
