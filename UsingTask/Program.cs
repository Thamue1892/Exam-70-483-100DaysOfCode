﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t = Task.Run(() =>
              {
                  for (int x = 0; x < 100; x++)
                  {
                      Console.Write("*");
                  }
              });

            t.Wait();
        }
    }
}
