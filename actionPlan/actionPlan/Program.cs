using System;
using System.Threading;

namespace raceConditionsDemonstration
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("chose the type to start: \n 0 - exit \n 1 - not sync \n 2 - lock \n 3 - Monitor \n 4 - TimerCallback test ");
            // lock statement is a shorthand notation for working with the System.Threading.Monitor class
            Console.Write("input: ");
            int type = int.Parse(Console.ReadLine());
            // -----------------------------------------------------------------------------------------------
            if (type == 1)
            {
                Console.WriteLine("A few thread using the same source of data, so this leads to race conditions");
                Thread[] threads = new Thread[5];
                for (int i = 0; i < 5; i++)
                    threads[i] = new Thread(new ThreadStart(PrintNumbers))
                    {
                        Name = $"Worker Thread #{i}"
                    };
                foreach (Thread thread in threads)
                    thread.Start();
            }
            // -----------------------------------------------------------------------------------------------
            // Lock
            if (type == 2)
            {
                Thread[] threadsSync = new Thread[5];
                for (int i = 0; i < 5; i++)
                    threadsSync[i] = new Thread(new ThreadStart(PrintNumbersLock))
                    {
                        Name = $"Worker Thread #{i}"
                    };
                foreach (Thread thread in threadsSync)
                    thread.Start();
            }
            // -----------------------------------------------------------------------------------------------
            // Monitor
            if (type == 3)
            {
                Thread[] threadsSync = new Thread[5];
                for (int i = 0; i < 5; i++)
                    threadsSync[i] = new Thread(new ThreadStart(PrintNumbersMonitor))
                    {
                        Name = $"Worker Thread #{i}"
                    };
                foreach (Thread thread in threadsSync)
                    thread.Start();
            }
            // -----------------------------------------------------------------------------------------------
            if (type == 4)
            {
                Console.WriteLine("***** Working with Timer type *****\n");
                TimerCallback timerCB = new TimerCallback(PrintTime);
                Timer t = new Timer(
                      timerCB,     // The TimerCallback delegate object.
                      null,       // Any info to pass into the called method (null for no info).
                      0,          // Amount of time to wait before starting (in milliseconds).
                      1000);      // Interval of time between calls (in milliseconds).
                Console.WriteLine("Hit Enter key to terminate...");
                Console.ReadLine();
            }
        }

        static void PrintTime(object state)
        {
            Console.WriteLine("Time is: {0}",
              DateTime.Now.ToLongTimeString());
        }

        private static void PrintNumbers()
        {
            // Display Thread info.
            Console.WriteLine("-> {0} is executing PrintNumbers()",
              Thread.CurrentThread.Name);
            // Print out numbers.
            for (int i = 0; i < 5; i++)
            {
                // Put thread to sleep for a random amount of time.
                Random r = new Random();
                Thread.Sleep(100 * r.Next(5));
                Console.Write("{0}, ", i);
            }
            Console.WriteLine();
        }


        private static object threadLock = new object();
        private static void PrintNumbersLock()
        {
            lock (threadLock)
            {
                // Display Thread info.
                Console.WriteLine("-> {0} is executing PrintNumbers()",
                  Thread.CurrentThread.Name);
                // Print out numbers.
                for (int i = 0; i < 5; i++)
                {
                    // Put thread to sleep for a random amount of time.
                    Random r = new Random();
                    Thread.Sleep(100 * r.Next(5));
                    Console.Write("{0}, ", i);
                }
                Console.WriteLine();
            }
        }

        public static void PrintNumbersMonitor()
        {
            Monitor.Enter(threadLock);
            try
            {
                // Display Thread info.
                Console.WriteLine("-> {0} is executing PrintNumbers()",
                  Thread.CurrentThread.Name);
                // Print out numbers.
                Console.Write("Your numbers: ");
                for (int i = 0; i < 5; i++)
                {
                    Random r = new Random();
                    Thread.Sleep(100 * r.Next(5));
                    Console.Write("{0}, ", i);
                }
                Console.WriteLine();
            }
            finally
            {
                Monitor.Exit(threadLock);
            }
        }
    }
}
