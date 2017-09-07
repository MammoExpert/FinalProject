using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MammoExpert.PatientServices.DB
{
    /// <summary>
    /// Предоставляет значения полученные из окна настройки подключения к базе данных
    /// </summary>
    public class DbSource
    {
        //Получае или задает описание провайдера
        public string DescriptionProvider { get; set; }
        /// <summary>
        /// Получает или задает значение имени хоста (IP адреса)
        /// </summary>
        public string Host { get; set; }
        /// <summary>
        /// Получает или задает значение порта подключения
        /// </summary>
        public string Port { get; set; }
        /// <summary>
        /// Получает или задает значение названия базы данных
        /// </summary>
        public string DataBase { get; set; }
        /// <summary>
        /// Получает или задает значение имени пользователя
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// Получает или задает значение пароля
        /// </summary>
        public string Password { get; set; }
    }
}
