using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Learn.Recursion
{
    public class Recursiontest
    {
        public void DO()
        {
            string s = Console.ReadLine();
            PrintFoler_and_Files_Inpath.rec(s, 0);
            Console.WriteLine(Getsize_of_PrintFoler_and_Files_Inpath.rec(s));
        }
    }



    //Recurion
    public static class PrintFoler_and_Files_Inpath
    {

        public static void rec(string path, int lvl)
        {

            foreach (var i in Directory.GetFiles(path))
                Console.WriteLine($"{new string('-', lvl)} {new FileInfo(i).Name}");

            foreach (var i in Directory.GetDirectories(path))
            {
                Console.WriteLine($"{new string('-', lvl)} {new DirectoryInfo(i).Name}");
                rec(i, lvl + 1);
            }
        }
    }

    public static class Getsize_of_PrintFoler_and_Files_Inpath
    {
        static long ret = 0;
        public static long rec(string path)
        {

            foreach (var i in Directory.GetFiles(path))
                ret += new FileInfo(i).Length;

            foreach (var i in Directory.GetDirectories(path)) ret += rec(i);

            return ret;
        }
    }
}
