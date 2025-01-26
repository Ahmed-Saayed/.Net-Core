using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace C_Learn.Fundamental___Basics
{
    public class Basics
    {

        public void DO()
        {

            /*
           Copy
           int num = 42;
           object obj = num; // Boxing
           int num2 = (int)obj; // Unboxing 
           */

            /*
             string name=Console.ReadLine();

             Console.WriteLine($"My name {name}");
             Console.WriteLine(name.Contains("12"));
             Console.WriteLine(name.ToUpper());
             Console.WriteLine(name.StartsWith('a'));
             Console.WriteLine(name.StartsWith("a",StringComparison.OrdinalIgnoreCase));
             Console.WriteLine(name.IndexOf("a"));
             Console.WriteLine(name.LastIndexOf("a"));
             Console.WriteLine(name.Replace("pato","ahmed"));
             name = name.ToLower();
             Console.WriteLine(name);
             Console.WriteLine("================================");
      
            
            string s = "123{0}567{1}";
            s = string.Format(s, "but in first id", "but in second id");
            Console.WriteLine(s);
  
            s=Console.ReadLine();
            s = s.Trim();                   // remove leading and trailling spaces
            Console.WriteLine(s);
            var sub=s.Substring(2, 3);
            Console.WriteLine(sub);
            */

            /*
               public  const int n=61;              
               public readonly int ho = 60;         
            */
            //readonly can nit assign when i created and assign it once in constructor But const assign when created only





            /*
            Random rnd = new Random();
            int num = rnd.Next(1, 1000);
            Console.WriteLine(num);
            */

            /*
            string[] s = {"ab", "cd","ef"};
            string t = string.Join(" , ", s);
            Console.WriteLine(t);
            */


            /*
            int x = int.Parse(Console.ReadLine());
            string s=x.ToString();
            int b=int.Parse(s);         //to int

            Console.WriteLine(x + 5);
            Console.WriteLine(int.MinValue);
            Console.WriteLine(int.MaxValue);            
            Console.WriteLine(dfs(x));
            Console.WriteLine(--x);
            */


            // Array
            /*
            int []x = new int[3],y=new int[3];
            x[0] = 1;
            x[1] = 2;
            Console.WriteLine(x.Sum());
            Array.Copy(x, y, x.Length);

            long[] x = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();  // cin one line
            */

            /*
            var x = new List<int>();
            x= Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int k = x.Aggregate((x, y) => x ^ y);
            Console.WriteLine(k);
            */

            /*
            var x = new List<int>{ 1,2,3,4,5,6};

            var y = x.FirstOrDefault(x => x % 2 == 0 && x>5);
            Console.WriteLine(y);
            */
        }
}
}
  
