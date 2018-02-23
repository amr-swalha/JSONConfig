using System;
using JsonConfiguration;
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
        [Test]
        public void GetSqlData()
        {
            JsonConfigurationSource source = new JsonConfigurationSource(new JsonConfigurationDataSource(SourceType.Database,"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=JSONConfig;Data Source=."));
            var result = source.Read("test");
            Assert.IsTrue(result.IsSuccessed);
        }
    }
}
