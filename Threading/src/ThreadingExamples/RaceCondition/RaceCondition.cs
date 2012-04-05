using System;
using System.Threading;

namespace RaceCondition
{
    /// <summary>
    /// Uses threads to count up to a number, in a way that is not safe.
    /// </summary>
    class RaceCondition
    {
        public static int unsafeCounter = 0;
        public static int safeCounter = 0;
        
        static void Main()
        {
            const int threadCount = 64;
            ManualResetEvent[] doneEvents = new ManualResetEvent[threadCount];
            for (int i = 0; i < threadCount; i++)
            {
                doneEvents[i] = new ManualResetEvent(false);
                ThreadPool.QueueUserWorkItem(new Worker(doneEvents[i]).IncrementCounter, null);
            }
            WaitHandle.WaitAll(doneEvents);
            Console.WriteLine("Finished:");
            Console.WriteLine("Unsafe: " + unsafeCounter);
            Console.WriteLine("  Safe: " + safeCounter);
            Console.WriteLine("...");
            Console.ReadLine();
        }
    }
    
    class Worker
    {
        ManualResetEvent done;
        
        public Worker(ManualResetEvent done)
        {
            this.done = done;
        }
        
        public void IncrementCounter(object context)
        {
            for (int i = 0; i < 100; i++)
            {
                // unsafe: we grab the value of unsafeCounter, alter that value, and
                // store the value back to unsafeCounter.  If there is a context-switch
                // between those operations, the value written back will be incorrect.
                //
                // we force a context switch here by sleeping.
//                Console.WriteLine("Old Value: " + RaceCondition.unsafeCounter);
//                int register = RaceCondition.unsafeCounter + 1;
//                Thread.Sleep(1);
//                RaceCondition.unsafeCounter = register;
//                Console.WriteLine("New Value: " + RaceCondition.unsafeCounter);
                                
                
                // unsafe:  the ++ operator has the same problems as above, however 
                // it is harder to demonstrate: 
                int expectedCounter = ++RaceCondition.unsafeCounter;
                Thread.Sleep(1);
                // unsafeCounter may have been modified by another thread before we execute this line:
                if (expectedCounter != RaceCondition.unsafeCounter)
                {
                    Console.WriteLine("Didn't get the unsafeCounter we expected! " + expectedCounter + " not " + RaceCondition.unsafeCounter);
                }

                // this is always safe:
                Interlocked.Increment(ref RaceCondition.safeCounter);
            }
            done.Set();
        }
    }
}
