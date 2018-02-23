namespace JsonConfiguration
{
    /// <summary>
    /// Represent the source of the data, and the connection to it
    /// </summary>
	public class JsonConfigurationDataSource : IJsonConfigurationDataSource
	{
		public JsonConfigurationDataSource(SourceType sourceType, string connection)
		{
		    SourceType = sourceType;
		    Connection = connection;
		}
        /// <summary>
        /// The connection to the configs source, can be a database connection string/ a file path/ a web URL
        /// </summary>
	    public string Connection { get; set; }
        /// <summary>
        /// Type of the source: <see cref="SourceType"/>
        /// </summary>
	    public SourceType SourceType { get; set; }
	}
}
