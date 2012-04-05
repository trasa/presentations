/* Copyright 2008 Tony Rasa trasa@meancat.com
 * Licensed under the Apache License, Version 2.0 (the "License"); 
 * you may not use this file except in compliance with the License. 
 * You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
 * Unless required by applicable law or agreed to in writing, software distributed under 
 * the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF 
 * ANY KIND, either express or implied. See the License for the specific language 
 * governing permissions and limitations under the License.
 */
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
