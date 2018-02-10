using System;
using System.Collections.Generic;
using System.Text;

namespace JSONConfig.Source
{
	public interface IJsonConfigurationSource
	{
		IJsonConfigurationData Read(string key);

		IJsonConfigurationData Write(IJsonConfigurationData data);
	}
}
