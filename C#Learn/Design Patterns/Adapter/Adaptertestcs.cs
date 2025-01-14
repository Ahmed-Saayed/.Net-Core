using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Learn.Adapter
{
    public class Adaptertestcs
    {
        public void DO()
        {
            adaptee3 ad3 = new adaptee3();
            ad3.DO1();
        }
    }

    interface ITarget
    {
        void DO1();
        void DO2();
    }

    class Adaptee1 : ITarget
    {
        public void DO1()
        {
            Console.WriteLine("Adaptee1 DO1");
        }

        public void DO2()
        {
            Console.WriteLine("Adaptee1 DO2");
        }
    }

    class Adaptee2
    {
        public void DO1()
        {
            Console.WriteLine("Adaptee2 DO1");
        }

        public void DO2()
        {
            Console.WriteLine("Adaptee2 DO2");
        }

    }

    class adaptee3 : ITarget
    {
        private Adaptee2 adaptee2 = new Adaptee2();
        public void DO1()=>
            adaptee2.DO1();
        

        public void DO2()
        {
            adaptee2.DO2();
        }
    }
}
