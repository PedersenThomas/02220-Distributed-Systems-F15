using SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SharedModel.Messages;

namespace Display
{
    class Program
    {
        private static List<Thread> ThreadPool = new List<Thread>(); 
        static void Main(string[] args)
        {
            var ids = new List<string> { "display01", "display02", "display03" };
            Thread.Sleep(200);

            foreach (var id in ids)
            {
                var display = new Display(id);
                var thread = new Thread(display.Start);
                ThreadPool.Add(thread);

                thread.Start();
            }

            Console.WriteLine("Started {0} displays.", ThreadPool.Count);
            Console.ReadKey();
        }
    }
}
