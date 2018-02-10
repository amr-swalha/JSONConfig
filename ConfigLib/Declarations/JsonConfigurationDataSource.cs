using System;
using System.Collections.Generic;
using System.Text;

namespace JSONConfig.Source
{
	public class JsonConfigurationDataSource : IJsonConfigurationDataSource
	{
		public JsonConfigurationDataSource(SourceType sourceType, string connection)
		{
		    SourceType = sourceType;
		    Connection = connection;
		}

	    public string Connection { get; set; }
	    public SourceType SourceType { get; set; }
	}
}
