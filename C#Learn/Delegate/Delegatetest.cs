using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static C_Learn.Program;

namespace C_Learn.Delegate
{
    public class Delegatetest
    {
        public void DO()
        {
            del de = new del(meth);
            de = meth;   // i passed it by the way
            de("Void Delegate");

            dele de2 = new dele(add);
            Console.WriteLine(CalcOperation(2, 3, de2));
            Console.WriteLine(CalcOperation(2, 3, (x, y) => x / y));    // third parametar is a shape of delegate too
            Console.WriteLine(CalcOperation(2, 3, (x, y) => x * y));    // third parametar is a shape of delegate too


            de2 = add;                      // multicast degelate excute add then sub and return the final sub
            de2 += sub;
            de2 -= sub;                     // then when it call excute add only if u forget it take code to ChatGpt 
                        // del just have 1 method now (sub)

            Console.WriteLine(CalcOperation(2, 3, de2));
        }


        public delegate void del(string go);

        public delegate int dele(int x, int y);
        public static int CalcOperation(int x, int y, dele de)
        {
            return de(x, y);
        }
        public static int add(int a, int b) { return a + b; }
        static int sub(int x, int y) { return x - y; }
        public static void meth(string go) { Console.WriteLine(go); }
    }

}
