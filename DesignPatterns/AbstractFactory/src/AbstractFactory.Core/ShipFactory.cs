using System;
using AbstractFactory.Core.Extensions;

namespace AbstractFactory.Core
{
    public abstract class ShipFactory
    {
        public abstract IScout CreateScout();

        public abstract IFreighter CreateFreighter();
        
        public abstract IWarship CreateWarship();









        public IShip CreateRandomShip()
        {
            #region Creation Percentages 
            // yes this is a stupid way to handle this.
            const double WarshipPercent = .33;
            const double FreighterPercent = WarshipPercent + .33;
            
            #endregion

            double chance = rand.NextDouble();
            if (chance.Between(0.0, WarshipPercent))
                return CreateWarship();
            if (chance.Between(WarshipPercent, FreighterPercent))
                return CreateFreighter();
            return CreateScout();
        }
        
        private static readonly Random rand = new Random();

    }
}
