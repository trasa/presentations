using System;
using AbstractFactory.Core;
using Spring.Context;
using Spring.Context.Support;

namespace AbstractFactory.SpringLoaded
{
    class Program
    {
        static void Main()
        {

            // Get the red and blue factories (configured via Spring)
            IApplicationContext ctx = ContextRegistry.GetContext();
            ShipFactory redFactory = (ShipFactory)ctx.GetObject("RedFactory");
            ShipFactory blueFactory = (ShipFactory) ctx.GetObject("BlueFactory");



            BattleSimulator sim = new BattleSimulator(redFactory, blueFactory, 5);

            Console.WriteLine("Opening State:");
            Console.WriteLine(sim.Battlefield.ToString());
            sim.Fight();
            sim.Battlefield.ReportResultToConsole();
            Console.WriteLine("[Press Enter to Exit]");
            Console.ReadLine();
        }
    }
}
