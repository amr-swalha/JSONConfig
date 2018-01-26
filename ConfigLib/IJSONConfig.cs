using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonConfiguration
{
    public interface IJsonConfiguration
    {
        void ConfigurationSource(IConfigurationSource configurationSource);
    }

    public interface IConfigurationSource
    {
        void FileSource(string pathToFile);
        void WebSource(string pathToFile);
        void DbSource(string pathToFile);
    }

    class ConfigurationSource : IConfigurationSource
    {
        public void DbSource(string connectionString)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set the source of the configuration as file path
        /// </summary>
        /// <param name="pathToFile">The json file location</param>
        public void FileSource(string pathToFile)
        {
            throw new NotImplementedException();
        }

        public void WebSource(string url)
        {
            throw new NotImplementedException();
        }
    }
}
