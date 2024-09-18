using System;
using System.Linq;

namespace Linq
{
	class School
	{
		public Student[] Students { get; set; }
	}

	class Student
	{
		public string Name { get; set; }
	}


	public class Program
	{
		public static void Main()
		{

			var schools = new[] {
			new School(){ Students = new [] { new Student(){ Name="Bob"}, new Student(){ Name="Jack"} }},
			new School(){ Students = new [] { new Student(){ Name="Jim"}, new Student(){ Name="John"} }}
			};

			var allStudents = schools.Select(s => s.Students.Where(g => g.Name == "Jack"));

			foreach (var students in allStudents)
			{
				foreach (var student in students)
				{
					Console.WriteLine(student.Name);
				}
			}

			var allStudents1 = schools.SelectMany(s => s.Students.Where(g => g.Name == "Jack"), (a, b) => new { a.Students, b });
			//var allStudents = schools.SelectMany(s=> s.Students, (a, b) => new {a, b});

			foreach (var student in allStudents1)
			{
				//Console.WriteLine(student.b.Name);
				Console.WriteLine(student.Students[1].Name);
			}
			// cross join
			Student[] std1 = new[] { new Student() { Name = "Bob" }, new Student() { Name = "Jack" }, new Student() { Name = "Jack1" } };
			Student[] std2 = new[] { new Student() { Name = "Jim" }, new Student() { Name = "Jam" }, new Student() { Name = "Jam1" } };
			var allStudent_tuple = std1.SelectMany(t1 => std2.Select(t2 => Tuple.Create(t1, t2)));
			Console.WriteLine(allStudent_tuple.Count());
			foreach (Tuple<Student, Student> t in allStudent_tuple)
			{
				Console.WriteLine(t.Item1.Name);
			}
			// inner join
			var allStudents2 = std1.Join(std2, t => t.Name, s => s.Name, (t, s) => Tuple.Create(t, s));
			Console.WriteLine(allStudents2.Count());
		}
	}
}
