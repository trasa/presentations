using System;
using System.Threading;

namespace Deadlock
{
    /// <summary>
    /// Create a bunch of threads, and put em against each other --
    /// sooner or later, they'll block.
    /// </summary>
    class Deadlock
    {
        static void Main()
        {
            const int threadCount = 64;
            ManualResetEvent[] doneEvents = new ManualResetEvent[threadCount];
            State state = new State();
            for (int i = 0; i < threadCount; i++)
            {
                doneEvents[i] = new ManualResetEvent(false);
                Worker worker = new Worker(doneEvents[i]);
                ThreadPool.QueueUserWorkItem(worker.TakeAction, state);
            }

            // wait for completion
            Console.WriteLine("Waiting for Completion");
            WaitHandle.WaitAll(doneEvents);
            Console.WriteLine("Finished.");
        }
    }
    
    class Worker
    {
        ManualResetEvent done;
        
        public Worker(ManualResetEvent done)
        {
            this.done = done;
        }
        
        public void TakeAction(object context)
        {
            State state = (State)context;
            for (int i = 0; i < 100; i++)
            {
                state.FirstAction();
                // this is here to increase the chances of a context switch
                Thread.Sleep(1);
                state.SecondAction();
            }
            done.Set();
        }
    }
    
    class State
    {
        object lockA = new object();
        object lockB = new object();
        int counterA = 0;
        int counterB = 0;
        
        public void FirstAction()
        {
            // nesting locks == evil
            lock(lockA)
            {
                Console.WriteLine(counterA + "First Action First Lock");
                counterA++;
                lock(lockB)
                {
                    Console.WriteLine(counterB + "First Action Second Lock");
                    counterB++;
                }
            }
        }
        
        public void SecondAction()
        {
            // nesting locks == evil
            lock(lockB)
            {
                Console.WriteLine(counterB + "Second Action First Lock");
                counterB++;
                lock(lockA)
                {
                    Console.WriteLine(counterA + "Second Action Second Lock");
                    counterA++;
                }
            }
        }
    }
}
