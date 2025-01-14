using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Learn.Decorator
{
    public class Decoratortest
    {
        public void DO()
        {
            Sanwich op = new Shatta(new Beans(new Basicsanwich()));
           
            Console.WriteLine(op.getname());
            Console.WriteLine(op.getprice());
        }
    }

    interface Sanwich
    {
        string getname();
        int getprice();
    }

    class SanwichDecorator : Sanwich
    {
        private Sanwich sanwich;
        public SanwichDecorator(Sanwich sanwich)
        {
            this.sanwich = sanwich;
        }
        public virtual string getname()
        {
            return sanwich.getname();
        }

        public virtual int getprice()
        {
           return sanwich.getprice();
        }
    }

    class Basicsanwich : Sanwich
    {
        public string getname() => "Bread ";
        public int getprice()
        {
            return 5;
        }
    }

    class Beans : SanwichDecorator
    {
        public Beans(Sanwich sanwich) : base(sanwich) 
        {
            
        }
        public override string getname() => base.getname() + "Beans ";

        public override int getprice()
        {
            return base.getprice() + 2;
        }
    }

    class Shatta : SanwichDecorator
    {
        public Shatta(Sanwich sanwich) : base(sanwich)
        {

        }
        public override string getname() => base.getname() + "Shatta ";

        public override int getprice()
        {
            return base.getprice() + 10;
        }
    }
}
