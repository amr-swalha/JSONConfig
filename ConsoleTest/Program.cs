using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JSONConfig;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Configuration configuration = new Configuration(true);
            Console.WriteLine(configuration.ConfigValue("dbconnection"));
            Console.ReadLine();
        }
    }
}
