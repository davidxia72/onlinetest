using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
     // Last In First Out (LIFO)
     // Stack is generic and takes any data type
    public class Stack<T>
    {
        // implement with single linked list
        LinkedList<T> list = new LinkedList<T>();
        public void Push(T value)
        {
            list.AddFirst(value);
        }
        public T Pop()
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("The Stack is empty");
            }
            T value = list.First.Value;
            list.RemoveFirst();
            return value;
        }

        public T Peek()
        {
            if (list.Count == 0)
            {
                return default;
            }
            return list.First.Value;
        }
        public int GetSize()
        {
            return list.Count;
        }
        public bool IsEmpty()
        {
            return list.Count == 0 ? true : false;
        }
    }

}
