using System;

namespace Algo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Struct
            myStruct objStruct = new myStruct();
            objStruct.x = 10;
            Console.WriteLine("Initial value of Struct Object is: " + objStruct.x);
            Console.WriteLine();
            methodStruct(objStruct);
            Console.WriteLine();
            Console.WriteLine("After Method call value of Struct Object is: " + objStruct.x);
            Console.WriteLine();

            //Class
            myClass objClass = new myClass(10);
            Console.WriteLine("Initial value of Class Object is: " + objClass.x);
            Console.WriteLine();
            methodClass(objClass);
            Console.WriteLine();
            Console.WriteLine("After Method call value of Class Object is: " + objClass.x);
            Console.Read();

        }
        static void methodStruct(myStruct newStruct)
        {
            newStruct.x = 20;
            Console.WriteLine("Inside Struct Method");
            Console.WriteLine("Inside Method value of Struct Object is: " + newStruct.x);
        }

        static void methodClass(myClass newClass)
        {
            newClass.x = 30;
            Console.WriteLine("Inside Class Method");
            Console.WriteLine("Inside Method value of Class Object is: " + newClass.x);
        }
    }
}
