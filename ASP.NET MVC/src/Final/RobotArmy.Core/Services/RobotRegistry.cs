using RobotArmy.Core.Repositories;
using StructureMap.Configuration.DSL;

namespace RobotArmy.Core.Services
{
    public class RobotRegistry : Registry
    {
        public RobotRegistry()
        {
            Scan(scanner =>
                     {
                         scanner.TheCallingAssembly();
                         scanner.WithDefaultConventions();
                     });

            ForRequestedType(typeof(IRepository<>))
                .TheDefaultIsConcreteType(typeof(Repository<>));
        }
    }
}
