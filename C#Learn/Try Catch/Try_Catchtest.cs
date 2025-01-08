using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Learn.Try_Catch
{
    public class Try_Catchtest
    {
        public void DO()
        {
            try
            {
                int[] a = { 1, 2 };
                Console.WriteLine(a[5]);
                Console.WriteLine("hi");        // not executed
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }


            try
            {
                int a = 0;
                Console.WriteLine(5 / a);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {                       // Alwyas execute
                Console.WriteLine("DONE");
            }

            try
            {
                string s = Console.ReadLine();
                if (s.Length < 3)
                    throw new Exception("string must be at least 3");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
