using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 0;
            var task1 = DoCalculate();

            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine(await task1);
            Console.WriteLine(2);
            Console.ReadKey();

        }

        public static async Task<int> DoCalculate()
        {
            Console.WriteLine( Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(3000);
            return 1;
        }
    }
}
