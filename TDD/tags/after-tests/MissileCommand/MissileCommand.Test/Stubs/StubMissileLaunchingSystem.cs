using MissileCommand.Core;

namespace MissileCommand.Test.Stubs
{
    public class StubMissileLaunchingSystem : IMissileLaunchingSystem
    {
        public string SendLaunchOrders(FiringSolution solution)
        {
            return "Only pretended to fire a missile.  The world is safe.";
        }
    }
}
