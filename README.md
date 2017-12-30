
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

After that, Just create a new instance of the Configuration Class and you are all set to go. You can either pass the location of where your .json file is or let the library create one for you:


    Configuration configuration = new Configuration(true);//This will create the config file for us right next to the dll location

Now simply call ConfigValue and get the value of your desired config:

    configuration.ConfigValue("dbconnection");
The json file is just a really simple key value pair JSON:

    {
    	"dbconnection": "value"
    }

If your key does not exists, it will return empty string.

That's all :) Happy coding


