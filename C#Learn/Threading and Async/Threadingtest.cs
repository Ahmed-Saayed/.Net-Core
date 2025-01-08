using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Learn.Threading_and_Async
{
    public class Threadingtest                      // Search More for it !!!!!!!   Not worked !!
    {
        public async Task DO()
        {
            var cst = new CancellationTokenSource();
            Console.WriteLine("Main Thread ID1" + Environment.CurrentManagedThreadId);
            var tsk1 = Proccess1(cst.Token);
            var tsk2 = Proccess2(cst.Token);


            await Task.WhenAll(tsk1, tsk2);
            var name = Console.ReadLine();
            Console.ReadKey();
        }

        public object _lock = new();
        public async Task Proccess1(CancellationToken c)
        {


            for (int i = 0; i < 100; i++)
            {
                if (c.IsCancellationRequested) return;

                await Task.Delay(500);

                lock (_lock)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(i);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            return;
        }
        public async Task Proccess2(CancellationToken c)
        {
            for (int i = 0; i < 100; i++)
            {
                if (c.IsCancellationRequested) return;

                await Task.Delay(500);

                lock (_lock)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(i);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            return;
        }
    }
}