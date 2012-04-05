using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotArmy.Core.Model
{
    public class Robot
    {
        public virtual int Id { get; set;}
        public virtual string Name { get; set; }
        public virtual bool IsPsychotic { get; set; }
    }
}
