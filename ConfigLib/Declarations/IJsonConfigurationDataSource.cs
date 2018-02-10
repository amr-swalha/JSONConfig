using System;
using System.Collections.Generic;
using System.Text;

namespace JSONConfig.Source
{
	public interface IJsonConfigurationDataSource
	{
		string Connection
		{
			get;
			set;
		}

		SourceType SourceType
		{
			get;
			set;
		}
	}
}
