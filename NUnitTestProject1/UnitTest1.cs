using NUnit.Framework;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1;
using System;

namespace NUnitTestProject1
{
    public class Tests
    {
        private API testAPI;
        [SetUp]
        public void Setup()
        {
            testAPI = new API(null); //TODO find DBcontext 
        }

        [Test]
        public void TestGetCitizensDefaultArgs()
        {
            var testList = testAPI.GetCitizens();
            Assert.IsTrue(testList.Count == 12);
        }

        [Test]
        public void TestGetCitizensSexCorrectArgs()
        {
            var testList = testAPI.GetCitizens("female");
            Assert.IsTrue(testList.Count == 5);
        }

        [Test]
        public void TestGetCitizensSexIncorrectArgs()
        {
            try
            {
                var testList = testAPI.GetCitizens("trash");
            }
            catch (Exception warning)
			{
                Assert.AreEqual(warning, "Incorrect citizens sex value");
            }
        }

        [Test]
        public void TestGetCitizensAgeCorrectArgs()
        {
            var testList = testAPI.GetCitizens(default, 24, 31);
            Assert.IsTrue(testList.Count == 5);
        }

        [Test]
        public void TestGetCitizensAgeIncorrectArgs()
        {
            try
            {
                var testList = testAPI.GetCitizens(default, 24, 23);
            }
            catch (Exception warning)
            {
                Assert.AreEqual(warning, "Incorrect age range");
            }
        }

        [Test]
        public void TestGetCitizenCorrectArgs()
        {
            var testCitizen= testAPI.GetCitizen("qyfgqiyhwfoq1");
            Assert.IsTrue(testCitizen.name == "Stan Smith");
        }

        [Test]
        public void TestGetCitizenIncorrectArgs()
        {
            try
            {
                var testCitizen = testAPI.GetCitizen("qyfgqiyhwfoq2");
            }
            catch (Exception warning)
            {
                Assert.AreEqual(warning, "There is no citizen with same id");
            }
        }
    }
}