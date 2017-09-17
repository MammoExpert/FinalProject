using System;
using System.Diagnostics;
using MammoExpert.PatientServices.Core;
using MammoExpert.PatientServices.Core.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace MammoExpert.PatientServices.Tests.Core
{
    [TestFixture]
    public class PatientTest
    {
        [Test]
        public void Patient_Field_ValidateRequired_Incorrect(
            [Values(null, "", " ")] string value,
            [Values(nameof(Patient.FirstName), nameof(Patient.LastName), nameof(Patient.MiddleName))] string fieldName
        )
        {
            var patient = new Patient();

            patient.GetType().GetProperty(fieldName)?.SetValue(patient, value);

            Assert.Throws(typeof(RequiredException), () => patient.ValidateFieldValue(value));
        }



        [Test]
        public void Patient_Field_ValidateIncorrectSymbol_Incorrect(
            [Values("Name1", "Name.", "Name~")] string value,
            [Values(nameof(Patient.FirstName), nameof(Patient.LastName), nameof(Patient.MiddleName))] string fieldName
        )
        {
            var patient = new Patient();

            patient.GetType().GetProperty(fieldName)?.SetValue(patient, value);

            Assert.Throws(typeof(IncorrectSymbolException), () => patient.ValidateFieldValue(value));
        }
    }
}

//var prop = patient.GetType()?.GetProperty(fieldName);
//Assert.IsTrue(prop.GetValue(patient) == value);