
namespace AbstractFactory.Core
{
    public enum Fleet
    {
        Red,
        Blue
    }

    public struct BattleResult
    {
        private readonly Fleet? winner;
        private readonly IShip red;
        private readonly IShip blue;

        public BattleResult(Fleet? winner, IShip red, IShip blue)
        {
            this.winner = winner;
            this.red = red;
            this.blue = blue;
        }

        public Fleet? Winner { get { return winner;} }

        public override string ToString()
        {
            if (Winner == null)
                return "A Tie!";
            if (Winner == Fleet.Red)
                return BuildResultMessage(Fleet.Red, red, blue);
            return BuildResultMessage(Fleet.Blue, blue, red);
        }

        private static string BuildResultMessage(Fleet winnerFleet, IShip winner, IShip loser)
        {
            return string.Format("{0} {1} defeated {2}", winnerFleet, winner, loser);
        }
    }
}
