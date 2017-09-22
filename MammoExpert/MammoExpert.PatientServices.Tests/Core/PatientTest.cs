using System;
using System.Diagnostics;
using MammoExpert.PatientServices.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace MammoExpert.PatientServices.Tests.Core
{
    [TestFixture]
    public class PatientTest
    {
        [Test]
        public void Patient_Field_ValidateIncorrectValue_Incorrect(
            [Values(null, "", " ", "Name1", "Name.", "Name~")] string value,
            [Values(nameof(Patient.FirstName), nameof(Patient.LastName), nameof(Patient.MiddleName))] string fieldName
        )
        {
            var patient = new Patient();
            patient.GetType().GetProperty(fieldName)?.SetValue(patient, value);
            Assert.Throws(typeof(Exception), () => patient.ValidateNameValue(value));
        }

        [Test]
        public void Patient_Field_ValidateCorrectValue_Correct(
            [Values(nameof(Patient.FirstName), nameof(Patient.LastName), nameof(Patient.MiddleName))] string fieldName
        )
        {
            var patient = new Patient();
            var prop = patient.GetType().GetProperty(fieldName);
            prop?.SetValue(patient, "Имя");
            Assert.DoesNotThrow(() => patient.ValidateNameValue(prop?.Name));
        }

        [Test]
        public void Patient_Birthdate_ValidateDefaultDate_Incorrect()
        {
            var patient = new Patient();
            patient.BirthDate = Convert.ToDateTime(default(DateTime));
            Assert.Throws(typeof(DateAbsentException), () => patient.ValidateBirthDate());
        }

        [Test]
        public void Patient_Birthdate_ValidateCorrectValue_Correct()
        {
            var patient = new Patient();
            patient.BirthDate = Convert.ToDateTime("01/09/1988");
            Assert.DoesNotThrow(() => patient.ValidateBirthDate());
        }

        [Test]
        public void Patient_Telephone_ValidateForbiddenSymbol_Incorrect()
        {
            var patient = new Patient();
            patient.Telephone = "123~";
            Assert.Throws(typeof(ForbiddenSymbolException), () => patient.ValidateTelephone());
        }

        [Test]
        public void Patient_Telephone_ValidateForbiddenPunctuation_Incorrect()
        {
            var patient = new Patient();
            patient.Telephone = "123#";
            Assert.Throws(typeof(ForbiddenPunctuationException), () => patient.ValidateTelephone());
        }

        [Test]
        public void Patient_Telephone_ValidateHasLetter_Incorrect(
            [Values("123j", "123й")] string value
            )
        {
            var patient = new Patient();
            patient.Telephone = value;
            Assert.Throws(typeof(HasLetterException), () => patient.ValidateTelephone());
        }

        [Test]
        public void Patient_Telephone_ValidateCorrectValue_Correct(
            [Values("123-", "123)", "(123", "123+", "123 2134")] string value
        )
        {
            var patient = new Patient();
            patient.Telephone = value;
            Assert.DoesNotThrow(() => patient.ValidateTelephone());
        }
    }
}