using System;
using AbstractFactory.Core;
using AbstractFactory.Core.Martians;
using AbstractFactory.Core.Terrans;
using AbstractFactory.Core.Pirates;

namespace AbstractFactory.Simple
{
    class Program
    {
        static void Main(string[] args)
        {
//            BattleSimulator sim = new BattleSimulator(
//                new MartianShipFactory(), 
//                new TerranShipFactory(), 5);
            
            BattleSimulator sim = new BattleSimulator(
                new TerranShipFactory(), 
                new PirateShipFactory(),  5);
            //BattleSimulator sim = new BattleSimulator(new MartianShipFactory(), new PirateShipFactory(), 5);


            Console.WriteLine("Opening State:");
            Console.WriteLine(sim.Battlefield.ToString());
            sim.Fight();
            sim.Battlefield.ReportResultToConsole();
            Console.WriteLine("[Press Enter to Exit]");
            Console.ReadLine();
        }

    }
}
