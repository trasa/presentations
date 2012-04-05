using System;
using AbstractFactory.Core.Extensions;

namespace AbstractFactory.Core
{
    public static class CombatDecider
    {
        private static Random rand = new Random();

        public static BattleResult Fight(IShip red, IShip blue)
        {
            // determine two combat numbers:
            double redCombat = rand.NextDouble();
            double blueCombat = rand.NextDouble();

            redCombat += red.CombatModifier;
            blueCombat += blue.CombatModifier;

//            Console.WriteLine("Red Number: " + redCombat);
//            Console.WriteLine("Blue Number: " + blueCombat);

            if(redCombat.IsApproximatelyEqualTo(blueCombat))
                return new BattleResult(null, red, blue);
            return redCombat > blueCombat ? 
                new BattleResult(Fleet.Red, red, blue) : 
                new BattleResult(Fleet.Blue, red, blue);
        }
    }
}
