namespace JsonConfiguration
{
	public interface IJsonConfigurationSource
	{
		IJsonConfigurationData Read(string key);

		IJsonConfigurationData Write(IJsonConfigurationData data);
	}
}
