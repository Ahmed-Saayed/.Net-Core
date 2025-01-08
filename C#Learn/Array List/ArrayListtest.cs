using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Learn.Array_List
{
    public class ArrayListtest
    {
        public void DO()
        {
            ArrayList lst = new ArrayList();
            lst.Add(1);
            lst.Add("PATO");
            lst.Add(2.65464);
            lst.Add('a');
            lst.Add(true);
            lst.Add(new object());

            lst.RemoveRange(0, 1);
            lst.AddRange(new int[] { 2, 3, 4 });

            Console.WriteLine(lst.IndexOf("PATO", 2));             //the second parametar 2 is the starting posstion and  i can remove it

            string s = (string)lst[0];   // every element in arraylist is an object 

            foreach (var i in lst)
                Console.WriteLine(i); 
        }
    }
}
