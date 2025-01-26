using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Learn.Hash_Set
{
    public class SortedSettest
    {
        public void DO()
        {
            SortedSet<int> st = new SortedSet<int>();
            st.Add(1);
            st.Add(2);
            st.Remove(1);

            var st2 = st;            //  int sz= st.Count;

            int[] x = new int[1];
            x[0] = 2;
            if (st.SetEquals(x)) Console.WriteLine("YES");

            if (st.Contains(1)) Console.WriteLine("YES");

            Console.WriteLine(st.IsSubsetOf(st2));
        }
    }
}
