using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimeLogi;
using System.IO;

namespace PrimeLogiTests
{
    [TestClass]
    public class Tests
    {
        private const string PATH = "PrimeLogi.xml";

        [TestInitialize]
        public void Initialization()
        {
            if (!File.Exists(PATH))
            {
                var content = new[]
                {
                    "<PrimeLog>",
                    "<log name=\"Testy\">",
                    "<location name=\"Środowisko1\" path=\"log.txt\" filter=\"*.*\"/>",
                    "</log>",
                    "</PrimeLog>"
                };

                File.WriteAllLines(PATH, content);

            }
        }

        [TestMethod]
        public void XmlLoadTest()
        {
            var list = new XMLEngine().GetLogs();

            Assert.AreEqual(1, list.Count);

            Assert.AreEqual("Testy", list[0].Name);

            Assert.AreEqual("Środowisko1", list[0].locationList[0].Name);
        }
    }
}
