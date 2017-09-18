using Microsoft.VisualStudio.TestTools.UnitTesting;
using MammoExpert.PatientServices.Worklist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MammoExpert.PatientServices.Core;
using Moq;

namespace MammoExpert.PatientServices.Tests.WorklistRepository
{
    [TestClass()]
    public class PatientRepositoryDicomTests
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