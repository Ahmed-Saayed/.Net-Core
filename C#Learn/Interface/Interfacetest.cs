using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Learn.Interface
{
    public class Interfacetest
    {
        public void DO()
        {
            IType1 type1 = new PC();
            type1.on();
            type1.off();


            IType2 type2 = new PC();
            PC pc = new PC();

            type1.restart();
            type2.restart();
            pc.restart();


            type1 = new Phone();
            type1.on();
            type1.off();
            type1.restart();

            type1.Dont_need_to_implement_it_in_childs_becuse_it_have_body_and_dont_have_compile_error();

        }
    }
    interface IType1
    {
        void on();
        void off();
        void restart();
        void Dont_need_to_implement_it_in_childs_becuse_it_have_body_and_dont_have_compile_error()
        {
            Console.WriteLine("Dont_need_to_implement_it_in_childs_becuse_it_have_body_and_dont_have_compile_error");
        }
    }
    interface IType2
    {
        void on();
        void off();
        void restart();

    }

    public class PC : IType1, IType2
    {
        public void on()                            //Simple Implicit implement
        {
            Console.WriteLine("PC Tunred On");
        }
        public void off()                           //Simple Implicit implement
        {
            Console.WriteLine("PC Turned OFF");
        }
        void IType1.restart()                           //Explicit implement
        {
            Console.WriteLine("PC Type1 Restarted");
        }
        void IType2.restart()                           //Explicit implement
        {
            Console.WriteLine("PC Type2 Restarted");
        }
        public void restart()                     //Simple Implicit implement
        {
            Console.WriteLine("PC Just Restarted");
        }
    }
    public class Phone : IType1, IType2
    {
        public void on()
        {
            Console.WriteLine("Phone Tunred On");
        }
        public void off()
        {
            Console.WriteLine("Phone Turned OFF");
        }
        void IType1.restart()
        {
            Console.WriteLine("Phone Type1 Restarted");
        }
        void IType2.restart()
        {
            Console.WriteLine("Phone Type2 Restarted");
        }
        public void restart()
        {
            Console.WriteLine("Phone Just Restarted");
        }
    }
}
