using System;
using System.Collections.Generic;
using System.Text;

namespace JSONConfig.Source
{
	public class JsonConfigurationData : IJsonConfigurationData
	{
	    public JsonConfigurationData()
	    {
	        Configs = new List<Dictionary<string, string>>();
	    }
	    public List<Dictionary<string, string>> Configs { get; set; }
	    public int Count { get; set; }
	    public Exception Error { get; set; }
	    public bool IsSuccessed { get; set; }
	}
}
