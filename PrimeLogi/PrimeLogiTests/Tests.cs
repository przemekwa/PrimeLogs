using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimeLogi;
using System.IO;

namespace PrimeLogiTests
{
    [TestClass]
    public class Tests
    {
        private const string PATH   = "PrimeLogi.xml";

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
        public void Load_Config_File_Test()
        {
            var list = new XmlEngine().GetLogs();

            Assert.AreEqual(1, list.Count);

            Assert.AreEqual("Testy", list[0].Name);

            Assert.AreEqual("Środowisko1", list[0].LocationList[0].Name);
        }

        [TestMethod]
        public void Config_File_Log_Name_Exist_Test()
        {
            var list = new XmlEngine().GetLogs();

            Assert.AreEqual("Testy", list[0].Name);
        }

        [TestMethod]
        public void Config_File_Location_Exist_Test()
        {
            var list = new XmlEngine().GetLogs();

            Assert.AreEqual("Środowisko1", list[0].LocationList[0].Name);
        }

        [TestMethod]
        public void Config_File_Path_Exist_Test()
        {
            var list = new XmlEngine().GetLogs();

            Assert.AreEqual("log.txt", list[0].LocationList[0].Path);
        }

        [TestMethod]
        public void Config_File_Filter_Exist_Test()
        {
            var list = new XmlEngine().GetLogs();

            Assert.AreEqual("*.*", list[0].LocationList[0].Filter);
        }

    }
}
