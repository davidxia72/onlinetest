using System;
using System.Threading;
using System.Threading.Tasks;

namespace Multi_Thread
{
    class Program
    {
        static void Main(string[] args)
        {
            string userinput = Console.ReadLine();
            if (userinput == "thread")
            {
                Akshay a = new Akshay();
                Thread worker1 = new Thread(a.Work1);
                Thread worker2 = new Thread(a.Work2);
                Thread worker3 = new Thread(a.Work3);
                WaitHandle[] waitHandles = new WaitHandle[] { a.event2, a.event3 };  // not necessary??
                worker1.Start();
                worker2.Start();
                worker3.Start();
                WaitHandle.WaitAny(new WaitHandle[] { a.event1 });  // wait on worker 1
                Console.WriteLine(a.result);
                Console.Read();
            }
            else if (userinput == "cancel")
            {
                using (var cts = new CancellationTokenSource())  // task is cancellable
                {
                    Task task = new Task(() => { LongRunningTask(cts.Token); });
                    task.Start();
                    Console.WriteLine("Operation Performing...");
                    if (Console.ReadKey().Key == ConsoleKey.C)
                    {
                        Console.WriteLine("Cancelling..");
                        cts.Cancel();
                    }
                    Console.Read();
                }
            }
            else if (userinput == "return")
            {
                Task<int> task = Task<int>.Factory.StartNew(() => 1);
                Console.WriteLine(task.Result);
            }
            else if (userinput == "async")
            {
                var myTask = ShowTodaysInfoAsync(); // call your method which will return control once it hits await
                Console.WriteLine("print first");                                    // now you can continue executing code here
                Console.WriteLine(myTask.Result); // wait for the task to complete to continue
                                                  // use result 
                Console.WriteLine("print after");
            }
            else
            {
                Semaphore s = new Semaphore();
                for (int i = 1; i <= 5; i++) new Thread(s.Enter).Start(i);
            }
        }

        public static async Task<string> ShowTodaysInfoAsync()
        {
            string message =
                $"Today is {DateTime.Today:D}\n" +
                "Today's hours of leisure: " +
                $"{await GetLeisureHoursAsync()}";

            Console.WriteLine(message);
            return "I am herer";
        }
        static async Task<int> GetLeisureHoursAsync()
        {
            Thread.Sleep(2000);
            DayOfWeek today = await Task.FromResult(DateTime.Now.DayOfWeek);

            int leisureHours =
                today is DayOfWeek.Saturday || today is DayOfWeek.Sunday
                ? 16 : 5;

            return leisureHours;
        }
        private static int LongRunningTask()
        {
            Thread.Sleep(3000);
            return 1;
        }
        private static void LongRunningTask(CancellationToken token)
        {
            for (int i = 0; i < 10000000; i++)
            {
                Thread.Sleep(1000);
                if (token.IsCancellationRequested)
                {
                    break;
                }
                else
                {
                    Console.WriteLine(i);
                }
            }

        }

    }
}