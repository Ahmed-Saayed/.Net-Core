using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Learn.Proxy
{
    public class Proxytest
    {
        public void DO()
        {
            var lst = new List<string>() { "youtupe", "facebook" ,"twiteer","codeforces" };

            Proxy p = new Proxy();
            foreach (var item in lst)p.Connect(item);
            
        }
    }

        interface InternetAccess
        {
            void Connect(string s);
        }
       
        public class Proxy : InternetAccess
        {
        public List<string> lst=new List<string>() { "youtupe","facebook","insta"};

       public Proxy(){}
            
       public void Connect(string s)
        {
            
                Console.WriteLine((lst.Contains(s)?"Invalid ":"Valid ") + s);
        }

    }
}
