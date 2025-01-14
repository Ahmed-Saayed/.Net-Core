using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Learn.Observer
{
    public class Observertest
    {
        public void DO()
        {
            student s1 = new student("Ahmed");
            student s2 = new student("Mohamed");

            course c = new course();
            
            c.register(s1);
            c.register(s2);

            c.setmessage("ok");

            c.notify();
        }
    }

    interface Observe
    {
        void update(string message);
    }
    interface subject 
    {
        void register(Observe ops);
        void unregister(Observe ops);
        void notify();
    }

    class course : subject
    {
        private List<Observe> observers = new List<Observe>();
        private string message;
        public void register(Observe ops)
        {
            observers.Add(ops);
        }

        public void unregister(Observe ops)
        {
            observers.Remove(ops);
        }

        public void notify()
        {
            foreach (var observer in observers)
            {
                observer.update(message == "ok"? "Available": "UnAvailable");
            }
        }

        public void setmessage(string message)
        {
            this.message = message;
            notify();
        }
    }


    class student : Observe
    {
        private string name;
        public student(string name)
        {
            this.name = name;
        }
        public void update(string message)
        {
            Console.WriteLine("Hey " + name + " : " + message);
        }
       
    }
}
