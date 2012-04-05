using RobotArmy.Core.Model;
using RobotArmy.Core.Repositories;
using StructureMap;

namespace RobotArmy.Core.Services
{
    public class IoCConfigurationService
    {
        public static void Initialize()
        {
            ObjectFactory.Initialize(
                x =>
                    {
                        x.ForRequestedType(typeof(IRepository<>))
                            .TheDefaultIsConcreteType(typeof(Repository<>));
                        
                        x.ForRequestedType<IResetService>()
                            .TheDefaultIsConcreteType<ResetService>();

                    });
        }
    }
}
