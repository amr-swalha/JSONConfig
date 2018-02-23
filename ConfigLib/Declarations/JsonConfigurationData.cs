using System;
using System.Collections.Generic;

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
	}
}
