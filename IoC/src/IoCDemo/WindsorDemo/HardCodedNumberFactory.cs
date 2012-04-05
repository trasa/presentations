using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IoCDemo.WindsorDemo
{
    public class HardCodedNumberFactory : INumberFactory
    {
        public int Get()
        {
            return 42;
        }
    }
}
