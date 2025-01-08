using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Learn.Priority_Queue
{
    public class Priority_Queuetest
    {
        public void DO()
        {
            PriorityQueue<string, int> pq = new PriorityQueue<string, int>();


            pq.Enqueue("ahmed", 1);
            pq.Enqueue("TOTO", 3);
            pq.Enqueue("PATO", 2);



            while (pq.Count > 0)
            {
                var task = pq.Dequeue();
                Console.WriteLine($"Processing: {task}");
            }
        }
    }
}
