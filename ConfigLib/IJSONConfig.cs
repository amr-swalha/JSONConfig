using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonConfiguration
{
    public interface IJsonConfiguration
    {
        void ConfigurationSource();
    }

    public interface IConfigurationSource
    {
        void FileSource(string pathToFile);
    }

    class ConfigurationSource : IConfigurationSource
    {
        /// <summary>
        /// Set the source of the configuration as file path
        /// </summary>
        /// <param name="pathToFile">The json file location</param>
        public void FileSource(string pathToFile)
        {
            throw new NotImplementedException();
        }
    }
}
