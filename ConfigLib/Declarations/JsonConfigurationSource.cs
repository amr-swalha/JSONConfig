using System;
using System.Collections.Generic;
using System.Data;
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
        #region Declarations
        public IJsonConfigurationDataSource DataSource { get; set; }
        public JsonConfigurationSource(IJsonConfigurationDataSource dataSource)
        {
            DataSource = dataSource;
        }
        #endregion

        #region DataOperations
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
                            connection.Open();
                            SqlDataAdapter adapter = new SqlDataAdapter("JsonConfig_Read_Key",connection);
                            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                            adapter.SelectCommand.Parameters.AddWithValue("@key", key);
                            DataSet ds = new DataSet();
                            adapter.Fill(ds);
                            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                            {
                                result.Configs.Add(new Dictionary<string, string> { { key, ds.Tables[0].Rows[0][0].ToString() } });
                                result.IsSuccessed = true;
                            }
                            else
                            {
                                result.IsSuccessed = false;
                            }
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
        #endregion

        #region InternalHelpers

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

        #endregion
    }
}
