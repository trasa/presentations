using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MissileCommand.Core
{
    public interface IVectorProvider
    {
        IList<double> GetTargetingVectors();
    }
}
