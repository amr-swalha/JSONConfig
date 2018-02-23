using System;
using System.Collections.Generic;

namespace JsonConfiguration
{
	public interface IJsonConfigurationData
	{
		List<Dictionary<string, string>> Configs
		{
			get;
			set;
		}

		int Count
		{
			get;
			set;
		}

		Exception Error
		{
			get;
			set;
		}

		bool IsSuccessed
		{
			get;
			set;
		}
	}
}
