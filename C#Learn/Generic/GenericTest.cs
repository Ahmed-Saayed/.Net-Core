using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace C_Learn.Generic
{
    public class GenericTest
    {
        public void DO()
        {
            var lst = new GenericList<Types>();
            lst.add(new Types { Type1 = "11", Type2 = "2", Type3 = "3" });          // search for how to print lst
            lst.add(new Types { Type1 = "11", Type2 = "2", Type3 = "3" });

            Console.WriteLine(Push(1,5.5));
            //Console.WriteLine(Push("ahmed" ,"PATO"));
            Console.WriteLine(sub(3,2));
        }

        public T Push<T>(T x, T y) where T : INumber<T> => x + y;           // after => equals to body of the method{ return x+y }
        public int sub(int a, int b) => a - b;
    }
    public class Types
    {
        public string Type1 { get; set; }
        public string Type2 { get; set; }
        public string Type3 { get; set; }
    }
    public class GenericList<T>
    {
        public List<T> lst = new();

        public void add(T type)
        {
            lst.Add(type);
        }
    }
}
// where any somehing in the you want   
//public class GenericList<T,T2>where T : int where T2 : class  
//{
//}
