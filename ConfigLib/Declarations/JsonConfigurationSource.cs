using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;

namespace JSONConfig.Source
{
    public class JsonConfigurationSource : IJsonConfigurationSource
    {
        public IJsonConfigurationDataSource DataSource { get; set; }
        public JsonConfigurationSource(IJsonConfigurationDataSource dataSource)
        {
            DataSource = dataSource;
        }
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
                        var itemFile = new Dictionary<string, string>();
                        var searchResultFile = Jil.JSON
                            .Deserialize<Dictionary<string, string>>(System.IO.File.ReadAllText(DataSource.Connection))
                            .FirstOrDefault(x => x.Key == key);
                        itemFile.Add(key, string.IsNullOrEmpty(searchResultFile.Value) ? "" : searchResultFile.ToString());
                        result.IsSuccessed = !string.IsNullOrEmpty(searchResultFile.Value);
                        result.Configs.Add(itemFile);
                        break;
                    case SourceType.Url:
                        using (WebClient wc = new WebClient())
                        {
                            var json = wc.DownloadString(DataSource.Connection);
                            var itemUrl = new Dictionary<string, string>();
                            var searchResultUrl = Jil.JSON
                                .Deserialize<Dictionary<string, string>>(json)
                                .FirstOrDefault(x => x.Key == key);
                            itemUrl.Add(key, string.IsNullOrEmpty(searchResultUrl.Value) ? "" : searchResultUrl.ToString());
                            result.IsSuccessed = !string.IsNullOrEmpty(searchResultUrl.Value);
                            result.Configs.Add(itemUrl);
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

        public IJsonConfigurationData Write(IJsonConfigurationData data)
        {
            return null;
        }
    }
}
