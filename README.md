
 JSON.Config [![NuGet](https://img.shields.io/badge/nuget-1.0-blue.svg)](https://www.nuget.org/packages/JSON.Config)
-----------
So this is you trying to handle all these missed up config files written in xml. 

![](https://fat.gfycat.com/OrangeVastAntarcticgiantpetrel.gif)

With JSON.Config, say goodbye to missed up configurations. And you can have your configs placed in one place where you can have all your applications access it and read the needed configs.

Currently the Package are quite simple, and we hope that we can advanced it even more. It uses the super fast [Jil](https://github.com/kevin-montrose/Jil) as it's JSON serializer/Deserialize. 

Getting Started
---------------

Very simple, just go to NuGet Package Console Manager and Install JSON.Config:

    Install-Package JSON.Config

After that, Just create a new instance of the **JsonConfigurationSource** Class and you are all set to go. You will have to pass the source of the JSON for the JsonConfigurationSource so it can read it for you. Remember that you can pass either a web url, a local file or database as follow:

Local File:

    JsonConfigurationSource source = new JsonConfigurationSource(newJsonConfigurationDataSource(SourceType.FilePath,AppDomain.CurrentDomain.BaseDirectory+@"config.json"));

Web URL:

    JsonConfigurationSource source = new JsonConfigurationSource(new JsonConfigurationDataSource(SourceType.Url,"https://jsonplaceholder.typicode.com/posts/1"));

Database (Please check the notes!):

    JsonConfigurationSource source = new JsonConfigurationSource(new JsonConfigurationDataSource(SourceType.Database,"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=JSONConfig;Data Source=."));

After setting the source of the JSON, just simply call the Read Method so it give you back the value you desired:

    var result = source.Read("connectionString");

The data returned inside the result is from type JsonConfigurationData, which contains the following:

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
            /// <summary>
            /// Get the first occurrence of the value
            /// </summary>
            public string Configuration
            {
                get
                {
                    if (!IsSuccessed) return "";
                    return Configs.Count > 0 ? Configs.First().First().Value : "";
                }
            }
        }

Now either use Configs or Configuration to access the value. In case of error you will find the Exception details inside the Exception property and the IsSuccessed flag will be false.



Notes:
For the Database source, you can use the following sample sql to create a sample table and the stored procedure to get the value for you.

[Sql Table](https://gist.github.com/amr-swalha/59852ceb69e6744cff22b57faffe833b)
[Sql Stored Procedure](https://gist.github.com/amr-swalha/7fea37a554cbdcf6b640205da8d07c56)

Happy Coding :)

Please support our site TutorialsXL.com which contains online courses for programming and supports open source projects like this!
