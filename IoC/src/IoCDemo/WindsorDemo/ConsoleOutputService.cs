using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IoCDemo.WindsorDemo
{
    public class ConsoleOutputService : IOutputService
    {
        public void WriteLine(string s)
        {
            Console.WriteLine(s);
        }

        public void Write(string s)
        {
            Console.Write(s);
        }
    }
}
