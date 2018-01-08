using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadStaticAttribute
{
    class Program
    {
        [ThreadStatic]
        public static int _field;

        public static void Main()
        {
            new Thread(() =>
            {
            for (int x = 0; x < 10; x++)
            {
                _field++;
                Console.WriteLine("ThreadA:{0}", _field);
        }
    }).Start();

    new Thread(() =>
    {
         for(int x= 0; x<10; x++)
                    {
                        _field++;
                        Console.WriteLine("Thread B: {0}", _field);
                    }
                }).Start();
            Console.ReadKey();
  
        }
    }
}
