using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using JSONConfig;
using NUnit.Framework;

namespace Lib.Test
{
    [TestFixture]
    public class MainTests
    {
        [TestCase()]
        public void GetKey()
        {
            Configuration configuration = new Configuration("config.json");
            var result = configuration.ConfigValue("dbconnection");
            Assert.IsNotEmpty(result);
        }

        [TestCase()]
        public void GetNonExistingKey()
        {
            Configuration configuration = new Configuration("config.json");
            var result = configuration.ConfigValue("connectionString1");
            Assert.IsEmpty(result);
        }
        [TestCase()]
        public void PathCorrect()
        {
            Configuration configuration = new Configuration("config.json");
            var path = configuration.ConfigurationPath + configuration.ConfigFile;
            Assert.IsTrue(File.Exists(path));
        }
        [TestCase()]
        public void CreateConfigFile()
        {
            Configuration configuration = new Configuration(true);
            var path = configuration.ConfigurationPath + configuration.ConfigFile;
            Assert.IsTrue(File.Exists(path));
        }
    }
}
