using System;
using System.Collections.Generic;
using System.Text;

namespace GCC
{
    using System;
    using System.Threading;

    class TestGC //: IDisposable
    {
        bool is_disposed = false;
        public void print()
        {
            Console.WriteLine("print job");
            System.Diagnostics.Trace.WriteLine("before finalizer is called.");
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!is_disposed) // only dispose once!
            {
                if (disposing)
                {
                    Console.WriteLine("Not in destructor, OK to reference other objects");
                }
                // perform cleanup for this object
                Console.WriteLine("Disposing...");
            }
            this.is_disposed = true;
        }

        public void Dispose()
        {
           // Console.WriteLine("start disposing");
          //  Dispose(true);
            // tell the GC not to finalize
            //GC.SuppressFinalize(this);
        }

        ~TestGC()
        {
            //Thread.Sleep(5000);
            //Dispose(true);
            Console.WriteLine("In destructor.");
            System.Diagnostics.Trace.WriteLine("Third's finalizer is called.");
        }
    }
}
