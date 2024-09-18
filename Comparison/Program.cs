using System;

namespace Comparison
{
    class Program
    {
        static void Main(string[] args)
        {
            OdpSummaryLoad load = new OdpSummaryLoad();
            load.Status = OdpSummaryLoadStatus.Loading;
            if (load.Status == OdpSummaryLoadStatus.Loading)
            {
                Console.WriteLine(load.Status);
                Console.WriteLine((int)load.Status);
            }
            if (load.Status == OdpSummaryLoadStatus.Pending)
            {
                Console.WriteLine(load.Status);
            }
        }
    }
}
