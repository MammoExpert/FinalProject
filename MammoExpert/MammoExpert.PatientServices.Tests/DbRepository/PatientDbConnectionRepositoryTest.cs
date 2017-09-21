using Microsoft.VisualStudio.TestTools.UnitTesting;
using MammoExpert.PatientServices.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using MammoExpert.PatientServices.Core;

namespace MammoExpert.PatientServices.Tests.DbRepository
{
    [TestClass()]
    public class PatientDbConnectionRepositoryTest
    {

        [TestMethod()]
        public void AddNewPatientTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void FindPatientsByValueTest()
        {
            var mock = new Mock<IPatientRepository>();
            mock.Setup(a => a.FindPatientsByValue(It.IsAny<string>())).Returns(new List<Patient>());
            Assert.IsNotNull(mock.Object);
        }

        [TestMethod()]
        public void GetAllPatientsTest()
        {
            var mock = new Mock<IPatientRepository>();
            mock.Setup(a => a.GetAllPatients()).Returns(new List<Patient>());
            Assert.IsNotNull(mock.Object);
        }

        [TestMethod()]
        public void GetPatientDataTest()
        {
            var mock = new Mock<IPatientRepository>();
            mock.Setup(a => a.GetPatientData(It.IsAny<string>())).Returns(new Patient());
            Assert.IsNotNull(mock.Object);
        }
    }
}