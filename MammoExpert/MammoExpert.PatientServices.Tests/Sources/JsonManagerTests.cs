using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using MammoExpert.PatientServices.Sources;
using NUnit;
using NUnit.Framework;

namespace MammoExpert.PatientServices.Tests.Sources
{
    [TestFixture]
    public class JsonManagerTests
    {
        private const string FakeJsonName = "fake_source_json_test.json";

        private string fakeJsonPath;

        private string pathToFolder;

        [SetUp]
        public void FakeJsonInit()
        {
            pathToFolder = @"D:\FinalProject\MammoExpert\MammoExpert.PatientServices.Tests\Sources";

            var path = Path.Combine(pathToFolder, "fake_source_json.json");

            fakeJsonPath = Path.Combine(pathToFolder, FakeJsonName);

            File.Copy(path, fakeJsonPath);
        }

        [TearDown]
        public void DropFakeJson()
        {
            if (File.Exists(fakeJsonPath))
            {
                File.Delete(fakeJsonPath);
            }
        }

        [Test]
        public void JsonManager_RepositoryAdd_IsCorrect()
        {

            var source = new Source(SourceTypeEnum.DataBase)
            {
                Description = "test",
                Name = "test",
                Id = 666
            };

            IRepository<Source> repository = new JsonManager(fakeJsonPath);

            repository.Add(source);

            IRepository<Source> repositoryAct = new JsonManager(Path.Combine(pathToFolder, "fake_source_json_act.json"));

            var items = repository.GetAll().AsEnumerable().ToArray();
            var itemsAct = repositoryAct.GetAll().AsEnumerable().ToArray();

            Assert.IsTrue(items.Length == itemsAct.Length);

            for (var i = 0; i < itemsAct.Length; i++)
            {
                Assert.IsTrue(items[i].Equals(itemsAct[i]));
            }
        }
    }
}