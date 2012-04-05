using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NLog;

namespace NLogDemoConsole
{
    class Program
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();


        static void Main()
        {
            log.Debug("Hello, World.");
            log.Fatal("LOL WAT");

            log.Debug("Lots of Good Information here too: http://www.nlog-project.org/tutorial.html");

            Console.WriteLine("[Hit Enter]");
            Console.ReadLine();
        }
    }
}
