using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework;
using NHibernate;

namespace HibernatingPirateShip
{
    class Program
    {
        static void Main()
        {
            IConfigurationSource source = ConfigurationManager.GetSection("activerecord") as IConfigurationSource;
            ActiveRecordStarter.Initialize(typeof(Program).Assembly, source);
            
            using (new SessionScope())
            {
                Order o = ActiveRecordMediator<Order>.FindByPrimaryKey(1);
                Console.WriteLine("Order initialized: " + NHibernateUtil.IsInitialized(o));
                Console.WriteLine("OrderLines initialized: " + NHibernateUtil.IsInitialized(o.OrderDetails));
                Console.WriteLine();

                Console.WriteLine("OrderName:" + o.Name);
                Console.WriteLine("Order initialized: " + NHibernateUtil.IsInitialized(o));
                Console.WriteLine("OrderLines initialized: " + NHibernateUtil.IsInitialized(o.OrderDetails));
                Console.WriteLine();

                Console.WriteLine("My Awesome Details:");
                foreach(var detail in o.OrderDetails)
                    Console.WriteLine(detail.Name);
                Console.WriteLine("OrderLines initialized: " + NHibernateUtil.IsInitialized(o.OrderDetails));
                
            }
            Console.Write("[Enter]");
            Console.ReadLine();
        }
    }
}
