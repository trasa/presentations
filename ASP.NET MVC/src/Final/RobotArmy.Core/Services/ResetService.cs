using RobotArmy.Core.Model;
using RobotArmy.Core.Repositories;

namespace RobotArmy.Core.Services
{
    public interface IResetService
    {
        void ClearPsychoRobots();
    }

    public class ResetService : IResetService
    {
        private readonly IRepository<Robot> robotRepository;

        public ResetService(IRepository<Robot> robotRepository)
        {
            this.robotRepository = robotRepository;
        }

        public void ClearPsychoRobots()
        {
            robotRepository
                .FindAll(new Robot {IsPsychotic = true})
                .ForEach(r => r.IsPsychotic = false);
        }
    }
}
