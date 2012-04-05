using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotArmy.Core.Model
{
    public interface IRobotViewModel
    {
        int Id { get; }
        string Name { get; }
    }

    public class RobotViewModel : IRobotViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
