using Microsoft.VisualStudio.TestTools.UnitTesting;
using MammoExpert.PatientServices.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Data.Common;

namespace MammoExpert.PatientServices.Tests.DbHelper
{
    [TestClass()]
    public class DbConnectionHelperTests
    {
      
        [TestMethod()]
        public void GetConnectionStringTest()
        {
            DbSource dbSource = new DbSource();
            DbConnectionHelper helper = new DbConnectionHelper(dbSource);
            string connection = helper.GetConnectionString("Odbc Data Provider");
            Assert.IsNotNull(connection);
          
        }

        [TestMethod()]
        public void GetListProvidersTest()
        {
            DbConnectionHelper helper = new DbConnectionHelper();
            IEnumerable<string> providers = helper.GetListProviders();
            Assert.IsNotNull(providers);
            Assert.AreEqual("Odbc Data Provider", providers.ElementAt(0));
        }

        [TestMethod()]
        public void GetProviderTest()
        {
            DbConnectionHelper helper = new DbConnectionHelper();
            string provider = helper.GetProvider("Odbc Data Provider");
            Assert.IsNotNull(provider);
        }

        [TestMethod()]
        public void GetStateConnectionTest()
        {
            DbSource dbSource = new DbSource();
            dbSource.Provider = "SqlClient Data Provider";
            dbSource.DataBase = "PatientServices";
            DbConnectionHelper helper = new DbConnectionHelper(dbSource);
            bool isConection = helper.GetStateConnection();
            Assert.IsNotNull(isConection);
        }

        [TestMethod()]
        public void CreateConnectionTest()
        {
            DbSource dbSource = new DbSource();
            dbSource.Provider = "SqlClient Data Provider";
            DbConnectionHelper helper = new DbConnectionHelper(dbSource);
            DbConnection connection = helper.CreateConnection();
            Assert.IsNotNull(connection);
        }
    }
}