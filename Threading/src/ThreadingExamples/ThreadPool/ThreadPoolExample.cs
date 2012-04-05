using System;
using System.Threading;

namespace ThreadPoolExample
{
    /// <summary>
    /// Short example of using a ThreadPool to create work items.
    /// </summary>
    class ThreadPoolExample
    {
        private const int MaxThreadCount = 10; // max # of workers at any given time
        private const int WorkItems = 30; // # of things  we're going to do
        
        static void Main()
        {
        
            ThreadPool.SetMaxThreads(MaxThreadCount, MaxThreadCount);
            Console.WriteLine("ThreadPool Example");
            
            // this will let our app know when we're doing processing everybody:
            // (this is here just for this example, otherwise the Main() will terminate early and 
            // end all the workers.)
            ManualResetEvent[] doneEvents = new ManualResetEvent[WorkItems];
            
            
            // queue up a whole bunch of file transfers.
            for (int i=0; i < WorkItems; i++)
            {
                // create a download work item -- 
                // values "i" and "doneEvents[i]" are needed only for 
                // the purposes of this sample...
                doneEvents[i] = new ManualResetEvent(false);
                FileDownloadWorkItem item = new FileDownloadWorkItem("File Details for " + i.ToString(), i, doneEvents[i]);
                ThreadPool.QueueUserWorkItem(item.TransferFile, null);
            }
            
            
            // wait for completion
            WaitHandle.WaitAll(doneEvents);
            Console.WriteLine("Finished.  Press Enter..");
            Console.ReadLine();
        }
    }
    
    class FileDownloadWorkItem
    {
        ManualResetEvent doneEvent; // Console App Example only
        int i; // Console App Example only
        string fileDetails; // replace with your "real" file details object

        static Random rand = new Random();
        
        public FileDownloadWorkItem(string fileDetails, int i, ManualResetEvent doneEvent)
        {
            this.fileDetails = fileDetails;
            this.i = i;
            this.doneEvent = doneEvent;
        }
        
        // the "Do It" method that the threadpool will call.
        // we're required to have a context object - this is the 2nd parameter passed to
        // ThreadPool.QueueUserWorkItem(item.TransferFile, null) -- maybe you have something
        // you'd actually want to use there...
        public void TransferFile(object context)
        {
            Console.WriteLine("Transferring file for Item " + i);
            // pretend to do something:
            // if you set this to a constant number, like "10000" (10 seconds) it is easy to see
            // how 10 workers execute, 10 seconds elapse, 10 more workers are started.
            // 
            // setting it to something random makes a more interesting demo tho.
            
            //Thread.Sleep(10000);
            Thread.Sleep(rand.Next(1000, 10000));
            
            Console.WriteLine("Finished File Transfer for " + i);
            doneEvent.Set();
        }
    }
}
