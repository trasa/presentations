using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PirateShipConsumer.MyPirateShipFactory;

namespace PirateShipConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            // call the service and build a ship:
            PirateShipFactorySoapClient client = new PirateShipFactorySoapClient();
            PirateShip ship = client.BuildShip("Lollipop");
            Console.WriteLine(ship.ToString());
            Console.WriteLine("Your ship is named '" + ship.Name + "'");
            Console.ReadKey();
        }
    }
}
