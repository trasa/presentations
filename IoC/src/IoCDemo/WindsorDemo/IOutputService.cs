using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IoCDemo.WindsorDemo
{
    public interface IOutputService
    {
        void WriteLine(string s);

        void Write(string s);
    }
}
