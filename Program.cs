using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.CommandLine;

namespace commandline_parsing_example
{
    class Program
    {

        static void Main(string[] args)
        {
            var configBuilder = new ConfigurationBuilder();

             var switches = new Dictionary<string, string>()
             {
                 { "-f", "foo" },
                 { "--foo", "foo" }
             };

            // Last one wins, so put lower-priority sources first!
            configBuilder.AddJsonFile("resources/config.json");
            configBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configBuilder.AddIniFile("resources/config.ini");
            configBuilder.AddCommandLine(args, switches);

            var config = configBuilder.Build();

            Console.WriteLine("--foo = {0}", config["foo"]);
            Console.WriteLine("ini file value asection:foo = {0}", config["asection:foo"]);
            Console.WriteLine("--bar = {0}", config["bar"]);
        }
    }
}
