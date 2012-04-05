using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using IoCDemo.WindsorDemo;

namespace IoCDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // XML Init Container:
            var container = new WindsorContainer(new XmlInterpreter());

            #region Fluent
            /*
            var container = new WindsorContainer();
            container.Register(
                Component.For<INumberFactory>()
                                .Instance(new HardCodedNumberFactory()),
                Component.For<IOutputService>()
                                .Instance(new ConsoleOutputService()),
                Component.For<Calculator>()
            );
             */
            #endregion

            // do something:
            var calculator = container.Resolve<Calculator>();
            calculator.Add();
            
            Console.ReadKey();
        }
    }
}
