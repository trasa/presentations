using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Common.Logging;

namespace NLogDemoConsoleCommon
{
    class Program
    {

        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            // common.logging, not NLOG
            log.Debug("the drummer from Def Leppards only got one arm.");

            Console.WriteLine("[Enter]");
            Console.ReadLine();
        }
    }
}
