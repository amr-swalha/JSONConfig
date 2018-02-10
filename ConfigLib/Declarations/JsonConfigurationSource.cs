using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Net;

namespace JSONConfig.Source
{
    /// <summary>
    /// Handles the read/write operations to the different data sources
    /// </summary>
    public class JsonConfigurationSource : IJsonConfigurationSource
    {
        public IJsonConfigurationDataSource DataSource { get; set; }
        public JsonConfigurationSource(IJsonConfigurationDataSource dataSource)
        {
            DataSource = dataSource;
        }
        /// <summary>
        /// To read the configs key and send back it's value
        /// </summary>
        /// <param name="key">Key name to get</param>
        /// <returns><see cref="IJsonConfigurationData"/> with the key info</returns>
        public IJsonConfigurationData Read(string key)
        {
            IJsonConfigurationData result = new JsonConfigurationData();
            try
            {
                switch (DataSource.SourceType)
                {
                    case SourceType.Database:
                        using (SqlConnection connection = new SqlConnection(DataSource.Connection))
                        {

                        }
                        break;
                    case SourceType.FilePath:
                        SearchKey(key,System.IO.File.ReadAllText(DataSource.Connection),ref result);
                        break;
                    case SourceType.Url:
                        using (WebClient wc = new WebClient())
                        {
                            var json = wc.DownloadString(DataSource.Connection);
                            SearchKey(key,json,ref result);
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                result.Error = e;
                result.IsSuccessed = false;
            }

            return result;
        }

        private void SearchKey(string key,string json,ref IJsonConfigurationData result)
        {

            var searchResultUrl = Jil.JSON
                .Deserialize<Dictionary<string, object>>(json)
                .FirstOrDefault(x => x.Key == key);
            var item = new Dictionary<string, string>
            {
                { key, string.IsNullOrEmpty(searchResultUrl.Value?.ToString()) ? "" : searchResultUrl.ToString() }
            };
            result.IsSuccessed = !string.IsNullOrEmpty(searchResultUrl.Value?.ToString());
            result.Configs.Add(item);
        }
        public IJsonConfigurationData Write(IJsonConfigurationData data)
        {
            IJsonConfigurationData result = new JsonConfigurationData();
            try
            {
                switch (DataSource.SourceType)
                {
                    case SourceType.Database:
                        break;
                    case SourceType.Url:
                        break;
                    case SourceType.FilePath:
                        break;
                }
            }
            catch (Exception e)
            {
                result.Error = e;
                result.IsSuccessed = false;
            }
            return result;
        }
    }
}
