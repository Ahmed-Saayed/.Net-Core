using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Learn.Extension_Methods
{
    public class ExtensionMethodstest
    {
        public void DO()
        {
            string s = Console.ReadLine();

            string t = s.DONE();                           //   or by this way ReverseMe.DONE(s);
            Console.WriteLine(t);

            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(Check_Range.DONE(n, 1, 5));           //   or by this way  n.DONE(1, 5)

        }
    }

    //Extension Methods
    public static class ReverseMe
    {
        public static string DONE(this string s)
        {
            return new string(s.Reverse().ToArray());
        }
    }
    public static class Check_Range
    {
        public static bool DONE(this int num, int l, int r)
        {
            return (num >= l && num <= r);
        }
    }
}
