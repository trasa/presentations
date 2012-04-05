using System;
using System.Collections.Generic;
using System.Text;
using AbstractFactory.Core;

namespace AbstractFactory.Core
{
   

    public class Battlefield
    {
        private readonly List<IShip> redShips = new List<IShip>();
        private readonly List<IShip> blueShips = new List<IShip>();
        private readonly Random rand = new Random();

        public void AddShip(Fleet fleet, IShip ship)
        {
            if (fleet == Fleet.Red)
                redShips.Add(ship);
            else
                blueShips.Add(ship);
        }

        public void Fight()
        {
            IShip redShip = GetRedShip();
            IShip blueShip = GetBlueShip();
            BattleResult result = CombatDecider.Fight(redShip, blueShip);
            RecordResult(result, redShip, blueShip);
        }

        public bool HasWinner
        {
            get
            {
                return redShips.Count == 0 || blueShips.Count == 0;
            }
        }

        public Fleet? Winner
        {
            get
            {
                if (redShips.Count > 0)
                    return blueShips.Count == 0 ? (Fleet?)Fleet.Red : null;
                return blueShips.Count > 0 ? (Fleet?)Fleet.Blue : null;
            }
        }

        public void ReportResultToConsole()
        {    
            Console.WriteLine("");
            Console.WriteLine("");
            
            Console.Write("Winner: ");
            if (Winner.HasValue)
                Console.WriteLine(Winner);
            else
                Console.WriteLine("Nobody" );

            Console.WriteLine("Battlefield State:");
            Console.WriteLine(ToString());
        }


        private IShip GetRedShip()
        {
            return GetShip(redShips);
        }

        private IShip GetBlueShip()
        {
            return GetShip(blueShips);
        }

        private void RecordResult(BattleResult result, IShip redShip, IShip blueShip)
        {
            Console.WriteLine(result.ToString());
            if (result.Winner.HasValue)
            {
                if (result.Winner == Fleet.Red)
                    blueShips.Remove(blueShip);
                else
                    redShips.Remove(redShip);
            }
            // otherwise it was a tie.
        }

        private IShip GetShip(IList<IShip> ships)
        {
            return ships[rand.Next(0, ships.Count)];
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.AppendLine("Red Ships:");
            redShips.ForEach(ship => s.AppendLine(ship.ToString()));
            s.AppendLine("Blue Ships:");
            blueShips.ForEach(ship => s.AppendLine(ship.ToString()));
            return s.ToString();
        }
    }
}