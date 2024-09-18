using System;

namespace Delegate_app
{
    public class Person { }
    public class Employee : Person { }
    class Program
    {
        static void AddToContacts(Person person)
        {
            // This method adds a Person object  
            // to a contact list.  
        }

        static void Test()
        {
            // Create an instance of the delegate without using variance.  
            Action<Person> addPersonToContacts = AddToContacts;

            // The Action delegate expects
            // a method that has an Employee parameter,  
            // but you can assign it a method that has a Person parameter  
            // because Employee derives from Person.  
            Action<Employee> addEmployeeToContacts = AddToContacts;

            // You can also assign a delegate
            // that accepts a less derived parameter to a delegate
            // that accepts a more derived parameter.  
            addEmployeeToContacts = addPersonToContacts;
        }
        static object GetObject() { return null; }
        static void SetObject(object obj) { Console.WriteLine(obj); }

        static string GetString() { return "5"; }
        static void SetString(string str) { }

       
        static void Main(string[] args)
        {
            // Covariance. A delegate specifies a return type as object,  
            // but you can assign a method that returns a string.  
            Func<object> del = GetString;

            // Contravariance. A delegate specifies a parameter type as string,  
            // but you can assign a method that takes an object.  
            Action<string> del2 = SetObject;

            Console.WriteLine(del());
            del2("tis is good");

            Predicate<string> predicate = (str) =>
            {
                double retNum;
                bool isNum = Double.TryParse(str, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
                return isNum;
            };
            bool found = predicate("djjddd");
        }
    }
}
