
using System;
using System.Collections.Generic;
using System.Linq;

namespace JSONConfig
{
    public class Configuration
    {
        /// <summary>
        /// The folder that holds the config file
        /// </summary>
        public string ConfigurationPath { get; set; }
        /// <summary>
        /// The name of the config file
        /// </summary>
        public string ConfigFile { get; set; }

        private string configuration => ConfigurationPath + ConfigFile;
        /// <summary>
        /// Create a new instance of Configuration, the default location of the file is the dll folder and the default name of the file is config.json
        /// </summary>
        public Configuration()
        {
            ConfigFile = "config.json";
            ConfigurationPath = AppDomain.CurrentDomain.BaseDirectory + ConfigFile;
        }
        /// <summary>
        /// Add the new config file name, make sure you place it right next to the dll.
        /// </summary>
        /// <param name="configFile">Name of the config file, recommended to have it ends with .json</param>
        public Configuration(string configFile)
        {
            ConfigFile = configFile;
            ConfigurationPath = AppDomain.CurrentDomain.BaseDirectory;
        }
        /// <summary>
        /// Set the entier configs where the file is located and the config file name
        /// </summary>
        /// <param name="configurationPath">The base path where you placed your config</param>
        /// <param name="configFile">Name of the config file, recommended to have it ends with .json</param>
        public Configuration(string configurationPath, string configFile)
        {
            ConfigurationPath = configurationPath;
            ConfigFile = configFile;
        }
        /// <summary>
        /// To get the key from the config file
        /// </summary>
        /// <param name="key">Name of the key</param>
        /// <returns>string of the config value</returns>
        public string ConfigValue(string key)
        {
            try
            {
                var configs = Jil.JSON.Deserialize<Dictionary<string, string>>(System.IO.File.ReadAllText(configuration));
                var result = configs.FirstOrDefault(x => x.Key == key).ToString();
                return result == "[, ]" ? "" : result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "error";
            }
        }
    }
}
