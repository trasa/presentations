using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private IRepository<Robot> robotRepository;

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
