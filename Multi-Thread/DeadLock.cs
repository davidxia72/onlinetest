using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Multi_Thread
{
    public class DeadLock
    {
        static readonly object firstLock = new object();
        static readonly object secondLock = new object();
        public void ThreadJob1()
        {
            lock (firstLock)
            {
                Console.WriteLine("\t\t\t\tLocked firstLock");
                // Wait until we're fairly sure the first thread
                // has grabbed secondLock
                Thread.Sleep(1000);
                Console.WriteLine("\t\t\t\tLocking secondLock");
                lock (secondLock)
                {
                    Console.WriteLine("\t\t\t\tLocked secondLock");
                }
                Console.WriteLine("\t\t\t\tReleased secondLock");
            }
            Console.WriteLine("\t\t\t\tReleased firstLock");
        }
        public void ThreadJob2()
        {
            lock (firstLock)
            {
                Console.WriteLine("sync, Locked secondLock");
                Console.WriteLine("sync, Locking firstLock");
                lock (secondLock)
                {
                    Console.WriteLine("sync, Locked firstLock");
                }
                Console.WriteLine("sync, Released firstLock");
            }
            Console.WriteLine("sync, Released secondLock");
        }

        public void ThreadJob_deadlock()
        {
            lock (secondLock)
            {
                Console.WriteLine("Locked secondLock");
                Console.WriteLine("Locking firstLock");
                lock (firstLock)
                {
                    Console.WriteLine("Locked firstLock");
                }
                Console.WriteLine("Released firstLock");
            }
            Console.WriteLine("Released secondLock");
        }
    }
}
