using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Learn.Abstract
{
    public class AbstractClasstest
    {
        public void DO()
        {
            /*
            Shape op = new Rectangle();
            op.print();
            op = new Circle();
            op.print();
            */
            animal op = new animal2();
            op.call();
        }
    }

    
    public abstract class animal
    {
        public int a, b;


        public void print()
        {
            Console.WriteLine(1);
        }
        public void call()
        {
            print();
        }

        public abstract void call2();
    }

    public class animal2 : animal
    {
        public int c, d;

        void print()
        {
            Console.WriteLine(2);
        }
        public void call()
        {
            base.call();
            print();
        }

        public override void call2()
        {              // if i make new instead of override it executes the base
            Console.WriteLine("abstract ");
        }

    }

    //=======================================================================

    abstract class Shape
    {
        protected string name;
        public abstract string Me();

        public virtual void print()
        {
            Console.WriteLine(Me());
        }
    }

    class Rectangle : Shape
    {
        public Rectangle()
        {
            name = "rectangle";
        }

        public override string Me()
        {
            return name;
        }
        public override void print()
        {
            base.print();
            Console.WriteLine("i can recall print in base and write extra somthings1");
        }

    }
    class Circle : Shape
    {
        public Circle()
        {
            name = "cir";
        }

        public string getname()
        {
            return name;
        }

        public override string Me()
        {
            return name;
        }
        public override void print()
        {
            base.print();
            Console.WriteLine("i can recall print in base and write extra somthings2");
        }
    }

}
