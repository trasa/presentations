using System.Collections.Generic;
using System.IO;

namespace MissileCommand.Core
{
    public class MainframeVectorProvider : IVectorProvider
    {
        private const string VectorFileName = "C:/FiringSolution_Mainframe_Info.txt";

        public IList<double> GetTargetingVectors()
        {
            if (!File.Exists(VectorFileName))
            {
                throw new DemoException("Couldn't find the pseudo-mainframe info file " + VectorFileName + ", did you forget to copy it?");
            }
            List<double> result = new List<double>();
            using (StreamReader sr = new StreamReader(File.OpenRead(VectorFileName)))
            {
                while (!sr.EndOfStream)
                {
                    // typically you'd check to make sure that the parse succeeds, or does something informative if the parse fails...
                    result.Add(double.Parse(sr.ReadLine()));
                }
            }
            return result;
        }
    }
}
