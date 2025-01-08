using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Learn.Stack_Queue
{
    public class Stacktest
    {
        public void DO()
        {

            Stack<string> stack = new Stack<string>();          //Queue<string> queue = new Queue<string>(); ez


            stack.Push("First");
            stack.Push("Second");
            stack.Push("Third");


            Console.WriteLine("Top item: " + stack.Peek());
            Console.WriteLine("Popping: " + stack.Pop());
            Console.WriteLine("Items in stack: " + stack.Count);
            Console.WriteLine("Contains 'First': " + stack.Contains("First"));

            // stack.Clear();
            Console.WriteLine("Items in stack after clear: " + stack.Count);
        }
    }
}
