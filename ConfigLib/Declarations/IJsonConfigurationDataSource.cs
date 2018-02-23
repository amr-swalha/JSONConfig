namespace JsonConfiguration
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
