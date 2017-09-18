using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using MammoExpert.PatientServices.Sources;
using MammoExpert.PatientServices.Tests.Sources.FakeData;
using NUnit;
using NUnit.Framework;

namespace MammoExpert.PatientServices.Tests.Sources
{
    [TestFixture]
    public class JsonManagerTests
    {
        private string pathToFolder = @"D:\FinalProject\MammoExpert\MammoExpert.PatientServices.Tests\Sources\FakeData";

        [Test]
        public void JsonManager_LoadRepository_IsCorrect()
        {
            var itemsExpected = new FakeJsonCollection().Collection.ToArray();
            
            var repositoryAct = new JsonManager(Path.Combine(pathToFolder, "fake_source_json_act.json"));

            var itemsAct = repositoryAct.Load().ToArray();

            Assert.IsTrue(itemsExpected.Length == itemsAct.Length);

            for (var i = 0; i < itemsAct.Length; i++)
            {
                Assert.IsTrue(itemsExpected[i].Equals(itemsAct[i]));
            }
        }
    }
}