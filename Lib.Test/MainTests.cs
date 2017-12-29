using System;
using System.Collections.Generic;
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
            var result = configuration.ConfigValue("connectionString");
            Assert.IsNotEmpty(result);
        }
    }
}
