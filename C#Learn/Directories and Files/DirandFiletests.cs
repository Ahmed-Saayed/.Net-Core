using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Learn.Directories_and_Files
{
    public class DirandFiletests
    {
        public void DO()
        {
            string path = Console.ReadLine();                       // path C:user/desktop   for ex

            foreach (var i in Directory.GetDirectories(path))           //get all paths folder in path
            {
                Console.WriteLine($"dir {i}");
            }


            foreach (var i in Directory.GetFiles(path))                 //get all paths files in path
            {
                Console.WriteLine($"file {i}");
            }


            // coment the 8 lines upove me to write the a correct path !!
            //Directory.CreateDirectory(path);
            // File.Create(path);
            // Console.WriteLine(File.ReadAllText(path));
            // there are more methods like appent , appentall, delete ,,,,
        }
    }
}
