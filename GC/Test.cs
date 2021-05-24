using System;
using System.Collections.Generic;
using System.Text;

namespace GCC
{
    class First
    {
        ~First()
        {
            System.Diagnostics.Trace.WriteLine("First's finalizer is called.");
        }
    }

    class Second : First
    {
        ~Second()
        {
            System.Diagnostics.Trace.WriteLine("Second's finalizer is called.");
        }
    }

    class Third : Second
    {
        ~Third()
        {
            System.Diagnostics.Trace.WriteLine("Third's finalizer is called.");
        }
    }
}
