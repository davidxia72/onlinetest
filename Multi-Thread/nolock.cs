using System;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

public class Program
{
	public void Main()
	{
		object lock1 = new object();
		object lock2 = new object();
		Console.WriteLine("Starting...");
		var task1 = Task.Run(() =>
		{
			int ticket_US = Tickets.NumofTicket_US;
			int ticket_CA = Tickets.NumofTicket_CA;
			Thread.Sleep(1000);
			Tickets.NumofTicket_US = ticket_US + 1;
			Tickets.NumofTicket_CA = ticket_CA + 1;
			Console.WriteLine("Finished Thread 1");

			Console.WriteLine("Thread 1, US ticket " + Tickets.NumofTicket_US.ToString());
			Console.WriteLine("Thread 1, CA ticket " + Tickets.NumofTicket_CA.ToString());
		});

		var task2 = Task.Run(() =>
		{

			int ticket_US = Tickets.NumofTicket_US;
			int ticket_CA = Tickets.NumofTicket_CA;
			Thread.Sleep(1000);
			Tickets.NumofTicket_CA = ticket_CA + 1;

			Tickets.NumofTicket_US = ticket_US + 1;
			Console.WriteLine("Finished Thread 2");

			Console.WriteLine("Thread 2, US ticket " + Tickets.NumofTicket_US.ToString());
			Console.WriteLine("Thread 2, CA ticket " + Tickets.NumofTicket_CA.ToString());
		});

		Task.WaitAll(task1, task2);
		Console.WriteLine("Finished...");
	}
}

public static class Tickets
{
	public static int NumofTicket_CA = 0;
	public static int NumofTicket_US = 0;
}


