using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Learn.Singleton
{
    public class singletontest
    {
        public void DO()
        {
            students op = students.ope;

            students op2 = students.ope;

            op.x++;
            Console.WriteLine(op2.x);       // out is 6
        }
    }



    public class students
    {

        public int x = 5;
        private students()
        {
        }

        public static students ope = new students();

    }


    // another define

    /*public class students
     {

         public int x = 5;
         private students()
         {
         }

         private static students ope;
         public static students ins 
         {
                 get{
                     if (ope == null)
                     {
                     ope = new students();
                     }

                     return ope;
                 }
             }
     }*/
}
