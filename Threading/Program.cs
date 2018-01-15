using System;
using System.Diagnostics;
using System.Threading;

namespace Threading
{
    class Program
    {
        static void Main(string[] args)
        {
            //Using stopwatch to time the code
            Stopwatch sw = Stopwatch.StartNew();

            //We call different methods for different
            //ways of running our application.
            RunInThreadPool();

            //Print the time it took to run the application.
            Console.WriteLine("We're done in {0}ms!",sw.ElapsedMilliseconds);
            if (Debugger.IsAttached)
            {
                Console.Write("Press any key to continue...");
                Console.ReadKey(true);
            }
        }

        private static void RunSequencial()
        {
            double result = 0d;

            //Call the function to read data from I/O.
            result += ReadDataFromIO();

            //Add result of the second calculation
            result += DoIntensiveCalculations();

            //Print the result
            Console.WriteLine("The result is {0}",result);
        }

        private static double DoIntensiveCalculations()
        {
            //We are simulating intensive calculations
            //by doing nonsense divisions.
            double result = 1000000000d;
            var maxValue = Int32.MaxValue;

            for (int i = 1; i < maxValue; i++)
            {
                result /= i;
            }
            return result + 10d;
        }

        private static double ReadDataFromIO()
        {
            //We are simulating an I/O by putting the thread to sleep.
            Thread.Sleep(5000);
            return 10d;
        }


        //Using the ThreadPool
        public static void RunInThreadPool()
        {
            double result = 0d;

            //Create a work item to read from I/O
            ThreadPool.QueueUserWorkItem((x) => result += ReadDataFromIO());

            //Save the result of the calculation into another variable.
            double result2 = DoIntensiveCalculations();
            //Wait for thread to finish

            //TODO:we will need a way to indicate when the 
            //thread pool thread finished the execution

            //Calculate the end result.
            Console.WriteLine("The result is {0}",result);
        }
    }
}
