﻿using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace MammoExpert.PatientServices.DB
{
    /// <summary>
    /// Представляет методы взаимодействия с подключением к базам данных.
    /// </summary>
    public class DbConnectionHelper
    {
        #region Constructors

        public DbConnectionHelper() { }
       
        public DbConnectionHelper(DbSource dbSource)
        {
            DbSource = dbSource;
        }

        #endregion //Constructors

        #region Property

        public DbSource DbSource { get; set; }

        #endregion //Property

        #region Public Metods

        /// <summary>
        /// Возвращает строку подключения к базе данных.
        /// </summary>
        /// <param name="descriptionProvider"></param>
        /// <returns></returns>
        public string GetConnectionString(string descriptionProvider)
        {
            switch (descriptionProvider)
            {
                case "Odbc Data Provider": return GetMySqlConnectionString(DbSource);
                case "OleDb Data Provider": return GetAccessConnectionString(DbSource);
                case "OracleClient Data Provider": return GetOracleConnectionSring(DbSource); 
                case "SqlClient Data Provider":  return GetSqlLocalTestConnectionString(DbSource);//GetSqlConnectionString(_dbSource);
                case "Microsoft SQL Server Compact Data Provider 4.0": return GetSqlCeConnectionString(DbSource);
                default: return GetSqlLocalTestConnectionString(DbSource);
            }
        }

        /// <summary>
        /// Возвращает список провайдеров зарегистрированных в системе.
        /// </summary>
        /// <returns></returns>
        public List<string> GetListProviders()
        {
            var providers = new List<string>();
            var dt = DbProviderFactories.GetFactoryClasses();

            foreach (DataRow row in dt.Rows)
                providers.Add(row[0].ToString());

            return providers;
        }

        /// <summary>
        /// Возвращает значение провайдера.
        /// </summary>
        /// <param name="descriptionProvider"></param>
        /// <returns></returns>
        public string GetProvider(string descriptionProvider)
        {
            var providers = GetDictionaryProviders();
            var provider = providers[descriptionProvider];
            return provider;
        }


        /// <summary>
        /// Возвращает состояние соединения.
        /// </summary>
        /// <param name="descriptionProvider"></param>
        public bool GetStateConnection()
        {
            var dbf = DbProviderFactories.GetFactory(GetProvider(DbSource.Provider));
            using (var connection = dbf.CreateConnection())
            {
                connection.ConnectionString = GetConnectionString(DbSource.Provider);
                connection.Open();

                if (connection.State == ConnectionState.Open) return true;

                return false;
            }
        }

        /// <summary>
        /// Возвращает соединие с базой данных.
        /// </summary>
        /// <returns></returns>
        public DbConnection CreateConnection()
        {
            var provider = GetProvider(DbSource.Provider);
            var dbf = DbProviderFactories.GetFactory(provider);
            var conn = dbf.CreateConnection();
            conn.ConnectionString = GetConnectionString(DbSource.Provider);
            return conn;
        }

        #endregion // Public Metods

        #region Privat Metods

        // Возвращает строку подключения к MySql базе данных.
        private string GetMySqlConnectionString(DbSource dbSource)
        {
            var connectionString = "Driver={MySQL ODBC 5.3 ANSI Driver};" +
                string.Format("Server={0};Port={1};Database = {2}; User = {3}; Password = {4}; Option = 3;",
                              dbSource.Host, dbSource.Port, dbSource.DataBase, dbSource.UserId,
                              dbSource.Password);

            return connectionString;
        }

        // Возвращает строку подключения к Access базе данных.
        private string GetAccessConnectionString(DbSource dbSource)
        {
            var connectionString =
                string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|{0}.accdb;" +
                              "Jet OLEDB: Database Password = {1};",
                              dbSource.DataBase, dbSource.Password);

            return connectionString;
        }

        // Возвращает строку подключения к Oracle базе данных.
        private string GetOracleConnectionSring(DbSource dbSource)
        {
            var connectionString =
                string.Format(@"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1}))
                             (CONNECT_DATA=(SERVICE_NAME={2})));User Id={3};Password={4};",
                             dbSource.Host, dbSource.Port, dbSource.DataBase,
                             dbSource.UserId, dbSource.Password);
            return connectionString;
        }

        // Возвращает строку подключения к Sql Compact базе данных.  
        private static string GetSqlCeConnectionString(DbSource dbSource)
        {
            var connectionString =
                string.Format("Data Source = " +
                System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) +
                "\\{0}.sdf; Persist Security Info = False;", dbSource.DataBase);
            return connectionString;
        }

        // Возвращает строку подключения к Sql Server базе данных.
        private string GetSqlConnectionString(DbSource dbSource)
        {
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = string.Format("{0},{1}", dbSource.Host, dbSource.Port);
            builder.NetworkLibrary = "DBMSSOCN";
            builder.InitialCatalog = dbSource.DataBase;
            builder.UserID = dbSource.UserId;
            builder.Password = dbSource.Password;
            builder.IntegratedSecurity = false;
            return builder.ToString();
        }

        // Возвращает строку подключения к локальной тестовой Sql Server базе данных.
        private string GetSqlLocalTestConnectionString(DbSource dbSource)
        {
            var connectionString =
                string.Format(@"Data Source=(localDb)\v11.0;AttachDbFilename=D:\FinalProject\Data\{0}.mdf;Integrated Security=True", dbSource.DataBase);
            return connectionString;
        }

        // Возвращает коллекцию провайдеров зарегистриванных в системе типа Dictionary.
        // c их описанием и значением
        private Dictionary<string, string> GetDictionaryProviders()
        {
            var providers = new Dictionary<string, string>();
            var dt = DbProviderFactories.GetFactoryClasses();

            foreach (DataRow row in dt.Rows)
                providers.Add(row[0].ToString(), row[2].ToString());

            return providers;
        }

        #endregion //Privat Metods
    }
}
