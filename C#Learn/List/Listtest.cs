using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Learn.List
{
    public class Listtest
    {
        public void DO()
        {
            List<int> v = new List<int>();
            v.Add(1);
            v.Add(2);
            v.Add(3);
            v.Add(4);

            v.Remove(2);
            v.Insert(1, 2);

            if (v.Contains(1))
                Console.WriteLine("YES");

            Console.WriteLine(v.IndexOf(4));
            Console.WriteLine(v.LastIndexOf(3));
            Console.WriteLine("List " + string.Join(", ", v));

            int[] x = v.ToArray();
            string s = string.Join(", ", x);


            var y = new List<emplo> {
                new("ahmed",1,1)
            };

            y.Add(new emplo ( "add", 1, 1 ));
        }
    }

    public class emplo
    {
        public string name { get; set; }
        public int age { get; set; }
        public long salary{ get; set; }

        public emplo(string nn,int ag,int sala)
        {
            name = nn; age = ag; salary = sala;
        }

    }
}
