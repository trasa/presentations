using System;
using System.Threading;

namespace ThreadAbort
{
    /// <summary>
    /// Create threads and try to abort them in a way that will 
    /// be harmful.
    /// </summary>
    class ThreadAbort
    {
        static void Main()
        {
            // this example creates a thread, then aborts it in a way that will
            // lock up this application.
            Thread t = new Thread(new ThreadStart(DoSomething));
            t.Start();
            
            Thread.Sleep(2000);
            
            Console.WriteLine("Aborting Thread...");
            // this doesn't "order" the thread to abort - it "sends a message"
            // that the thread should abort.  The Thead may choose to ignore
            // this message.
            t.Abort();
            
            Console.WriteLine("Trying to Join Aborted Thread...");
            // since our child thread ignored us, it will never terminate, 
            // and since we're using Join() and not Join(int), we will wait
            // indefinately for it...
            t.Join();
            
            // we don't ever get here:
            Console.WriteLine("Exiting..");
        }
        
        
        static void DoSomething()
        {
            while (true)
            {
                int i = Int32.MinValue;
                Console.WriteLine("Worker: Doing something");
                try
                {
                    // work happens.    
                    while (true)
                    {
                        i++;
                    }
                }
                catch (ThreadAbortException e)
                {
                    Console.WriteLine("Worker Exception: " + e.ToString());
                    Console.WriteLine("But we refuse to die!!");
                    Thread.ResetAbort();
                }
            }
        }
    }
}
