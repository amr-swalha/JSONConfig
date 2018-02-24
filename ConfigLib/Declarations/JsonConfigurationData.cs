using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace JsonConfiguration
{
    /// <summary>
    /// represent the data to send or get from the data source
    /// </summary>
	public class JsonConfigurationData : IJsonConfigurationData
    {
        public JsonConfigurationData()
        {
            Configs = new List<Dictionary<string, string>>();
        }
        /// <summary>
        /// List of the configs read from the json file
        /// </summary>
	    public List<Dictionary<string, string>> Configs { get; set; }
        /// <summary>
        /// Count of the configs
        /// </summary>
	    public int Count { get; set; }
        /// <summary>
        /// An exception if an error happened
        /// </summary>
	    public Exception Error { get; set; }
        /// <summary>
        /// is the retrieval/send process has successes or failed
        /// </summary>
	    public bool IsSuccessed { get; set; }
        /// <summary>
        /// Get the first occurrence of the value
        /// </summary>
        public string Configuration
        {
            get
            {
                if (!IsSuccessed) return "";
                var keyValue = Configs.First().First().Value.Replace('"',' ');
                keyValue = keyValue.Replace($"[{Configs.First().First().Key},", string.Empty).Replace(']', ' ').Trim();
                return Configs.Count > 0 ?  keyValue: "";
            }
        }
    }
}
