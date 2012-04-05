using System;
using System.Collections.Generic;
using System.Text;

namespace Singletons
{
    class Singletons
    {
        static void Main(string[] args)
        {
        }
    }
    
    
    class UnsafeExample
    {
        static UnsafeExample instance;
        
        public static UnsafeExample Instance
        {
            get
            {
                // not thread safe:
                if (instance == null)
                    instance = new UnsafeExample();
                return instance;
            }
        }
    }
}
