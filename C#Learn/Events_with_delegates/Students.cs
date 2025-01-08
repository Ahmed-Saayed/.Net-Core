using C_Learn.Events_with_delegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;  
using System.Threading.Tasks;

// Event With Delegate            // Event is Like a something taht hold a delegate and check if it null or invoke it see ChatGpt
namespace C_Learn.Events_with_delegates 
{
    public class Students{
        public delegate void Acces_me_by_event(Students st);
        public event Acces_me_by_event I_Hold_a_deleGte_Acces_me_by_event;

        public string name { get; set; }
        public int age { get; set; }

        public void Caluc(List<Students> lst)
        {
            foreach (var item in lst)
                I_Hold_a_deleGte_Acces_me_by_event?.Invoke(item);// as i say if the delegate in this event contains a method execue it 

        }
    }
}


public class Events_with_delegatestest{

    public void DO()
    {
        List<Students> list = new List<Students>();

        for (int i = 0; i < 2; i++)
        {
            list.Add(new Students
            {
                name = Console.ReadLine(),
                age = int.Parse(Console.ReadLine())
            }
            );
        }

        Students st = new Students();

        st.I_Hold_a_deleGte_Acces_me_by_event += print_st;              // hold the method
        st.Caluc(list);
    }
     public void print_st(Students st)
      {
         Console.WriteLine($"{st.name} {st.age}");
      }
}

 

