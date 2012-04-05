using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace SimpleUnity
{
    class Program
    {
        static void Main()
        {
            // unity walkthrough: http://msdn.microsoft.com/en-us/library/cc816062.aspx


            // load container:
            var container = new UnityContainer();
            var configSection = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            configSection.Containers.Default.Configure(container); // only one container defined

            var message = container.Resolve<IMessageService>();
            Console.WriteLine(message.GetMessage());
            Console.ReadLine();
        }
    }
}
