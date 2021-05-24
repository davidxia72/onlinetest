using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Multi_Thread
{
    public class Akshay
    {
        public int result = 0;
        public AutoResetEvent event1 = new AutoResetEvent(false);
        public AutoResetEvent event2 = new AutoResetEvent(false);
        public AutoResetEvent event3 = new AutoResetEvent(false);
        public void Work1()  // run last
        {
            WaitHandle.WaitAll(new WaitHandle[] { event2, event3 });
            result = 1;
            Thread.Sleep(5000);
            event1.Set();  // release 
        }
        public void Work2() { result = 2; Thread.Sleep(2000); event2.Set(); }
        public void Work3() { result = 3; event3.Set(); }

    }
}
