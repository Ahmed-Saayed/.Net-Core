using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace C_Learn.Enumerables
{
    public class Enumerablestest : IEnumerable<Items>       // to iterate from another class on this lst of another class
    {  
       private  List<Items> lst = new List<Items>();
       public void DO()
        {
            lst.Add(new Items
            {
                name = "Car",
                price = 50
            });

            lst.Add(new Items
            {
                name = "House",
                price = 300
            });

        }

        public IEnumerator<Items> GetEnumerator()           // auto bulid when i implements the interface above 
        {
            Console.WriteLine("Inume Called");              // the print excute when i do for loop
            foreach(var item in lst)
                yield return item;                   // yield like a bulid in that do the deeper things of the IEnumerator 
        }

        IEnumerator IEnumerable.GetEnumerator()              // auto bulid when i implements the interface above 
        {
            return GetEnumerator();
        }
    }
    
    public class Items
    {
        public string name { get; set; }
        public int price { get; set; }
    }
}
