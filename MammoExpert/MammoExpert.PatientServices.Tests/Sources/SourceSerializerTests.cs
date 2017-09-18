using System;
using System.Collections.Generic;
using MammoExpert.PatientServices.DB;
using MammoExpert.PatientServices.Sources;
using MammoExpert.PatientServices.Worklist;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Assert = NUnit.Framework.Assert;

namespace MammoExpert.PatientServices.Tests.Sources
{
    [TestFixture()]
    public class SourceSerializerTests
    {
        private DbSource db;
        private WorklistSource wl;
        private Source s_db;
        private Source s_wl;

        private string _name = "Name";
        private string _host = "127.192.104.1";
        private string _port = "8080";
        private int _id = 12;
        private string _password = "123";
        private string _provider = "Provider";
        private string _userId = "User";
        private string _title = "Title";
        private string _timeout = "2000";

        [SetUp]
        public void Serializer_Init()
        {
            db = new DbSource()
            {
                Id = 12,
                DataBase = _name,
                Host = _host,
                Password = _password,
                Port = _port,
                Provider = _provider,
                UserId = _userId
            };

             s_db = new Source(SourceTypeEnum.DataBase);
            s_db.Id = 12;
            s_db.Name = _name;
            s_db.Parameters["Ip"] = _host;
            s_db.Parameters["Port"] = _port;
            s_db.Parameters["Driver"] = _provider;
            s_db.Parameters["Password"] = _password;
            s_db.Parameters["UserName"] =_userId;

             wl = new WorklistSource()
            {
                Id = _id,
                Host = _host,
                Port = _port,
                AETitle = _title,
                DisplayName = _name,
                Timeout = 2000
            };

            s_wl = new Source(SourceTypeEnum.Worklist);
            s_wl.Id = 12;
            s_wl.Name = _name;
            s_wl.Parameters["Ip"] = _host;
            s_wl.Parameters["Port"] = _port;
            s_wl.Parameters["Header"] =_title;
            s_wl.Parameters["Timeout"] = _timeout;
        }

        [Test]
        public void DbSerialize_isCorrect()
        {
            var result = SourceSerializer.DbSerialize(db);
            Assert.IsTrue(result.Equals(s_db));
        }

        [Test]
        public void DbDeserialize_isCorrect()
        {
            var result = SourceSerializer.DbDeserialize(s_db);
            Assert.IsTrue(result.Equals(db));
        }

        [Test]
        public void WorklistSerialize_isCorrect()
        {
            var result = SourceSerializer.WorklistSerialize(wl);
            Assert.IsTrue(result.Equals(s_wl));
        }

        [Test]
        public void WorklistDeserialize_isCorrect()
        {
            var result = SourceSerializer.WorklistDeserialize(s_wl);
            Assert.IsTrue(result.Equals(wl));
        }
    }
}
