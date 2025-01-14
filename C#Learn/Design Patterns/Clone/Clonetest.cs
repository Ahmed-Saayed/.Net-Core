using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Learn.Clone
{
    public class Clonetest
    {
        public void DO()
        {
            st original = new st();
            original.x = 5;
            st clone = new st(original);

            original.x = 6;
            Console.WriteLine(clone.x);
        }
    }
    
    class st
    {
        public int x;
        public st() { }
        public st(st other)
        {
            if (other != null)
            {
                x = other.x;    // any thing you just need to pass object of the same class to return a clone of it
            }
        }
        public st Clone() => new st(this);
    }
}
