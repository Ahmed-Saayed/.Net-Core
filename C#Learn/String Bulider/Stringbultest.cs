using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Learn.String_Bulider
{
    public class Stringbultest
    {
        public void DO()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ahd");
            sb.AppendLine("Sayed");
            sb.Append("PATO");

            string s = sb.ToString();

            sb.Remove(0, 5);
            Console.WriteLine(sb);
        }
    }
}
