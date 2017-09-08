using MammoExpert.PatientServices.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MammoExpert.PatientServices.DB
{
    /// <summary>
    /// Представляет методы возвращающие сторки подключения к базам данных в зависмости от поставщика данных
    /// </summary>
    public class DbConnectionConfiguration
    {
        public DbConnectionConfiguration() { }
       
        public DbConnectionConfiguration(DbSource dbSource)
        {
            DbSource = dbSource;
        }

        public DbSource DbSource { get; set; }

        /// <summary>
        /// Возвращает строку подключения
        /// </summary>
        /// <param name="descriptionProvider"></param>
        /// <returns></returns>
        public string GetConnectionString(string descriptionProvider)
        {
            string connectionString = String.Empty;
            switch (descriptionProvider)
            {
                case "Odbc Data Provider":
                    connectionString = GetMySqlConnectionString(DbSource);
                    break;
                case "OleDb Data Provider":
                    connectionString = GetAccessConnectionString(DbSource);
                    break;
                case "OracleClient Data Provider":
                    connectionString = GetOracleConnectionSring(DbSource);
                    break;
                case "SqlClient Data Provider":
                    connectionString = GetSqlLocalTestConnectionString(DbSource);//GetSqlConnectionString(_dbSource);
                    break;
                case "Microsoft SQL Server Compact Data Provider 4.0":
                    connectionString = GetSqlCeConnectionString(DbSource);
                    break;
                default:
                    connectionString = GetSqlLocalTestConnectionString(DbSource);
                    break;
            }
            return connectionString;
        }

        /// <summary>
        /// Возвращает список провайдеров зарегистрированных в системе
        /// </summary>
        /// <returns></returns>
        public List<string> GetListProviders()
        {
            List<string> providers = new List<string>();
            DataTable dt = DbProviderFactories.GetFactoryClasses();

            foreach (DataRow row in dt.Rows)
                providers.Add(row[0].ToString());

            return providers;
        }

        /// <summary>
        /// Возвращает значение провайдера
        /// </summary>
        /// <param name="descriptionProvider"></param>
        /// <returns></returns>
        public string GetProvider(string descriptionProvider)
        {
            Dictionary<string, string> providers = GetDictionaryProviders();
            string provider = providers[descriptionProvider];
            return provider;
        }


        /// <summary>
        /// Возвращает состояние соединения
        /// </summary>
        /// <param name="descriptionProvider"></param>
        public void GetStateConnection()
        {
            try
            {
                DbProviderFactory dbf = DbProviderFactories.GetFactory(GetProvider(DbSource.Provider));
                using (DbConnection connection = dbf.CreateConnection())
                {
                    connection.ConnectionString = GetConnectionString(DbSource.Provider);
                    connection.Open();
                    if (connection.State == ConnectionState.Open)
                        Messager.ShowConnectionSuccess("Соединение с базой данных установленно!");
                }
            }
            catch (Exception exc)
            {
                Messager.ShowConnectionErrorMessage(exc);
            }
        }

        // Возвращает строку подключения к MySql базе данных
        private string GetMySqlConnectionString(DbSource dbSource)
        {
            string connectionString =
                String.Format("Driver={MySQL ODBC 5.3 ANSI Driver};Server={0};Port={1};" +
                              "Database = {2}; User = {3}; Password = {4}; Option = 3;",
                              dbSource.Host, dbSource.Port, dbSource.DataBase, dbSource.UserId,
                              dbSource.Password);
            return connectionString;

        }

        // Возвращает строку подключения к Access базе данных
        private string GetAccessConnectionString(DbSource dbSource)
        {
            string connectionString =
                String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|{0}.accdb;" +
                              "Jet OLEDB: Database Password = {1};",
                              dbSource.DataBase, dbSource.Password);

            return connectionString;
        }


        // Возвращает строку подключения к Oracle базе данных
        private string GetOracleConnectionSring(DbSource dbSource)
        {


            string connectionString =
                String.Format(@"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1}))
                             (CONNECT_DATA=(SERVICE_NAME={2})));User Id={3};Password={4};",
                             dbSource.Host, dbSource.Port, dbSource.DataBase,
                             dbSource.UserId, dbSource.Password);
            return connectionString;
        }

        // Возвращает строку подключения к Sql Compact базе данных  
        private static string GetSqlCeConnectionString(DbSource dbSource)
        {
            string connectionString =
                String.Format("Data Source = " +
                System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) +
                "\\{0}.sdf; Persist Security Info = False;", dbSource.DataBase);
            return connectionString;
        }


        // Возвращает строку подключения к Sql Server базе данных
        private string GetSqlConnectionString(DbSource dbSource)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = String.Format("{0},{1}", dbSource.Host, dbSource.Port);
            builder.NetworkLibrary = "DBMSSOCN";
            builder.InitialCatalog = dbSource.DataBase;
            builder.UserID = dbSource.UserId;
            builder.Password = dbSource.Password;
            builder.IntegratedSecurity = false;
            return builder.ToString();
        }


        // Возвращает строку подключения к локальной тестовой Sql Server базе данных
        private string GetSqlLocalTestConnectionString(DbSource dbSource)
        {
            string connectionString =
                String.Format(@"Data Source=(localDb)\v11.0;AttachDbFilename=E:\FinalProject\Data\{0}.mdf;Integrated Security=True", dbSource.DataBase);
            return connectionString;
        }

        // Возвращает коллекцию провайдеров зарегистриванных в системе типа Dictionary 
        // c их описанием и значением
        private Dictionary<string, string> GetDictionaryProviders()
        {
            Dictionary<string, string> providers = new Dictionary<string, string>();
            DataTable dt = DbProviderFactories.GetFactoryClasses();

            foreach (DataRow row in dt.Rows)
                providers.Add(row[0].ToString(), row[2].ToString());

            return providers;
        }  
    }
}
