//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Runtime.CompilerServices;

//namespace JsonConfiguration
//{
//    public interface IJsonConfiguration
//    {
//        void ConfigurationSource(IConfigurationSource configurationSource);
//    }

//    public interface IConfigurationSource
//    {
//        IJsonConfigurationData FileSource(string pathToFile);
//        IJsonConfigurationData WebSource(string urlToFile);
//        SqlConnection DbSource(string connectionString);
//    }

//    public interface IJsonConfigurationData
//    {
//        int Count { get; set; }
//        Dictionary<string, string> Configs { get; set; }
//        Exception Error { get; set; }
//        bool IsSuccessed { get; set; }
//    }

//    public interface IJsonConfigurationAccess
//    {
//        IJsonConfigurationData GetKey(string key);
//        IJsonConfigurationData AddKey(string key, object value);
//    }

//    public interface IJsonConfigurationDatabaseSource
//    {

//    }
//    public class JsonConfigurationAccess : IJsonConfigurationAccess
//    {
//        public IConfigurationSource ConfigurationSources { get; set; }   
//        public JsonConfigurationAccess(IConfigurationSource source)
//        {
//            ConfigurationSources = source;
//        }
//        public IJsonConfigurationData AddKey(string key, object value)
//        {
//            throw new NotImplementedException();
//        }

//        public IJsonConfigurationData GetKey(string key)
//        {
//            var data = new JsonConfigurationData();
         
            
//            return null;
//        }
//    }
//    public class JsonConfigurationData : IJsonConfigurationData
//    {
//        public int Count { get; set; }
//        public Dictionary<string, string> Configs { get; set; }
//        public Exception Error { get; set; }
//        public bool IsSuccessed { get; set; }
//    }
//    public class ConfigurationSource : IConfigurationSource
//    {
//        private static volatile ConfigurationSource _instance;
//        private static object syncRoot = new object();
//        public static ConfigurationSource Instance
//        {
//            get
//            {
//                if (_instance == null)
//                {
//                    lock (syncRoot)
//                    {
//                        if (_instance == null)
//                            _instance = new ConfigurationSource();
//                    }
//                }
//                return _instance;
//            }
//        }
//        private ConfigurationSource()
//        {

//        }

//        public SqlConnection DbSource(string connectionString)
//        {
//            var config = new JsonConfigurationData();
//            try
//            {
//                SqlConnection connection = new SqlConnection(connectionString);
//                return connection;
//            }
//            catch (Exception e)
//            {
//                config.Error = e;
//            }

//            return null;
//        }

//        /// <summary>
//        /// Set the source of the configuration as file path
//        /// </summary>
//        /// <param name="pathToFile">The json file location</param>
//        public IJsonConfigurationData FileSource(string pathToFile)
//        {

//            throw new NotImplementedException();
//        }

//        public IJsonConfigurationData WebSource(string url)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
