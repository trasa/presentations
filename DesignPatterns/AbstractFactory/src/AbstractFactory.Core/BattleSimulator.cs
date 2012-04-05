using AbstractFactory.Core;

namespace AbstractFactory.Core
{
    public class BattleSimulator
    {
        private readonly Battlefield field = new Battlefield();
        private readonly int shipCount;



        public BattleSimulator(ShipFactory redSide, 
            ShipFactory blueSide, 
            int shipCount)
        {
            this.shipCount = shipCount;
            // build a bunch of ships and put them into play.
            PopulateFleet(Fleet.Red, redSide);
            PopulateFleet(Fleet.Blue, blueSide);   
        }



        private void PopulateFleet(Fleet fleet, ShipFactory shipFactory)
        {
            // fill the battlefield with an appropriate number of ships on each side.
            for (int i = 0; i < shipCount; i++)
            {
                field.AddShip(fleet, shipFactory.CreateRandomShip());
            }
        }


        public void Fight()
        {
            // this many rounds of combat commences.
            for (int i=0; i < shipCount * 2; i++)
            {
                field.Fight();
                if (field.HasWinner)
                {
                    break;
                }
            }
        }


        public Battlefield Battlefield
        {
            get { return field; }
        }

    }
}