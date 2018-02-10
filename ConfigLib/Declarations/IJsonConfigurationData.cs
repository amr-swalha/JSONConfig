using System;
using System.Collections.Generic;
using System.Text;

namespace JSONConfig.Source
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
