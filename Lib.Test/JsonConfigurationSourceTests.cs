using System;
using JSONConfig.Source;
using NUnit.Framework;

namespace Lib.Test
{
    [TestFixture]
    public class JsonConfigurationSourceTests
    {
        [Test]
        public void GetFileData()
        {
            JsonConfigurationSource source = new JsonConfigurationSource(new JsonConfigurationDataSource(SourceType.FilePath,AppDomain.CurrentDomain.BaseDirectory+@"config.json"));
            var result = source.Read("connectionString");
            Assert.IsTrue(result.IsSuccessed);
        }
        [Test]
        public void GetUrlData()
        {
            JsonConfigurationSource source = new JsonConfigurationSource(new JsonConfigurationDataSource(SourceType.Url,"https://jsonplaceholder.typicode.com/posts/1"));
            var result = source.Read("userId");
            Assert.IsTrue(result.IsSuccessed);
        }
    }
}
