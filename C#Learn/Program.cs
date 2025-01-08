using C_Learn.Abstract;
using C_Learn.Array_List;
using C_Learn.Delegate;
using C_Learn.Directories_and_Files;
using C_Learn.Enumerables;
using C_Learn.Events_with_delegates;
using C_Learn.Extension_Methods;
using C_Learn.Fundamental___Basics;
using C_Learn.Generic;
using C_Learn.Hash_Set;
using C_Learn.Interface;
using C_Learn.LINQ;
using C_Learn.List;
using C_Learn.Map;
using C_Learn.Operator;
using C_Learn.Priority_Queue;
using C_Learn.Recursion;
using C_Learn.Stack_Queue;
using C_Learn.String_Bulider;
using C_Learn.Threading_and_Async;
using C_Learn.Try_Catch;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Channels;

namespace C_Learn
{
    internal class Program
    {
        static void Main()
        {


            /*!!!
            In summary, use abstract methods when you want to enforce a
            contract in subclasses, and use virtual methods 
            when you want to provide a default implementation that can be changed if necessary. 

            cannot create instance (op) from intercafe and abstract class
            you cannot declare a class as virtual
            */

            // static class any something declare within it must be static   and can access with call its name . name of the properite
            // static memebers can not reach any non-static members
            // in Extension Methods when we make this keyword it must define in static class (and in static class any method must be static)
            // abstract class cannot have a constructor (make object) only accessed from its childs
            // virtual members can edit on it in its childs classes
            // interface all thing inside it public by defualt and abstracted
            // Multiple interfaces can be inplemented by single class 
            // ref int x  =  int & x  when call in parametar function
            // ref must be initialize  but out not(but must initialize it)
            // enum  cant be double
            // new leyword instantiating objects
            // This  creates an instance of Dog but assigns it to a reference variable of type Animal.  Animal op = new Dog();   (focus on meaning)
            // Memort stack stop variables methods after excute main , heap objects 
            // a delegate can be thought of as a variable that stores a reference to a method, with the same signature
            // any class or method that contains event called publisher and any who listing to event called subscriber and event only made if void delegate
            // Static classes cannot be instantiated, and they cannot contain instance members.
            // Click and Select Go to implementation
            // Asynchronous programming allows a program to start a task and move on to another task before the first one finishes
            // Synchronous programming means program waits for each task to complete before moving on to the next one
            // await make thread Synchronous
            // () => ()     () its a parametar method / => / () its a returned of the method what ever void or any type
            //the join clause is used in LINQ to combine elements from two sequences based on a common key.(( The result new collection of anonymous objects))
            // Try To Understand Asyn await Task  Threads  !!!!!!!!!!!!!!!!!!!!!!!!!!

            //var op2 = new test { x = 5, y = 6 };
            //var op = new test() { x = 5, y = 6 };
            //var op3 = new test(1, 2);



            //var op4 = new List<test>();
            //op4.Add(new() { x = 2, y = 2 });// add object of test and {} for but any parametar  
            //op4.Add(new test { x = 1 });


            //==========================================================

            /*
            Basics op = new Basics();
            op.DO();
            */

            
            Interfacetest op = new Interfacetest();
            op.DO();
            

            /*
            HashSettest op = new HashSettest();
            op.DO();
            */

            /*
            Maptest op = new Maptest();
            op.DO();
            */

            /*
            Priority_Queuetest op = new Priority_Queuetest();
            op.DO();
            */

            /*
            ArrayListtest op=new ArrayListtest();
            op.DO();
            */

            /*
            Listtest op = new Listtest();
            op.DO();
            */

            /*
            Stacktest op = new Stacktest();
            op.DO();
            */

            /*
            Stringbultest op = new Stringbultest();
            op.DO();
            */

            /*
            ExtensionMethodstest op = new ExtensionMethodstest();
            op.DO();
            */

            /*
            Recursiontest op = new Recursiontest();
            op.DO();
            */

            /*
            Try_Catchtest op =new Try_Catchtest();
            op.DO();
            */

            /*
            DirandFiletests op=new DirandFiletests();
            op.DO();
            */

            /*
            AbstractClasstest op = new AbstractClasstest();
            op.DO();
            */

            /*
            Delegatetest op = new Delegatetest();
            op.DO();
            */

            /*
            Events_with_delegatestest op = new Events_with_delegatestest();
            op.DO();
            */

            /*
            Threadingtest op = new Threadingtest();     // not worked!
            op.DO();
            */

            /*
            Enumerablestest op = new Enumerablestest();
            op.DO();

            foreach (var i in op)                           // Here i call a list from class of class 
            {
                Console.WriteLine(i.name + " " + i.price);
            }
            */

            /*
            GenericTest op = new GenericTest();
            op.DO();
            */

            /*
            Linqtest op = new Linqtest();
            op.DO4();
            */
            /*
            Operatortest op = new Operatortest();
            op.DO();
            */

            // Typehere

            /*
            OP op=new OP();
            remote rm= new remote();

            add ad = new add(op);
            sub sb = new sub(op);

            rm.add(0, ad);
            rm.add(1, sb);

            rm.DOO(0);
            Console.WriteLine(op.x);
            rm.DOO(0);
            Console.WriteLine(op.x);
            rm.DOO(1);
            Console.WriteLine(op.x);*/






            /*
            // x initialy 0 
            par op=new par();
            op.x++;
            par op2 = op;

            op.x++;
            Console.WriteLine(op2.x);


            int x = 5;
            x++;
            int y = x;

            x++;
            Console.WriteLine(y);*/

            
           
        }
    }


 
        class OP{
        public int x = 5;

       public void addme()
        {
            x++;
        }
        public void subme()
        {
            x--;
        }

    }
    class add :Ido {
        OP op = new OP();
        public add(OP op)
        {
            this.op = op;
        }

        public void exe()
        {
            op.addme();
        }
    }

    class sub :Ido
    {
        OP op = new OP();
        public sub(OP op)
        {
            this.op = op;
        }

        public void exe()
        {
            op.subme();
        }
    }

    interface Ido
    {
        void exe();
    }

    class remote
    {
        Ido [] arr = new Ido[2];

       public void add(int id,Ido dd)
        {
            arr[id] = dd;
        }

       public void DOO(int id)
        {
            arr[id].exe();
        }
    }
}
