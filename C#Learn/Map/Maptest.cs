using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Learn.Map
{
    public class Maptest
    {
         public void DO() { 
            Dictionary<string, int> mp = new Dictionary<string, int>();

            mp.Add("Alice", 30);
            mp.Add("Bob", 25);
            mp.Add("Charlie", 35);

            Console.WriteLine("Alice's age: " + mp["Alice"]);

           
            if (mp.ContainsKey("Bob"))
            {
                Console.WriteLine("Bob's age: " + mp["Bob"]);
            }

            if (mp.TryGetValue("Charlie", out int charlieAge))
            {
                Console.WriteLine("Charlie's age: " + charlieAge);
            }
            
            bool ok = mp.TryGetValue("hehe", out int val);
            Console.WriteLine(val);

            mp.Remove("Alice");

            foreach (var kvp in mp)
            {
                Console.WriteLine($"{kvp.Key} is {kvp.Value} years old.");
            }

            //Console.WriteLine(mp["a"]);           runtime error u must check its in map or not
            
       
            mp.Clear();
            Console.WriteLine("Count after clearing: " + mp.Count);
            }
    }
}
