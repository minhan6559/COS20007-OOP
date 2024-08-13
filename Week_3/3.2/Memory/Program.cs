using System;
namespace CounterTask
{
    internal class Program
    {
        private static void PrintCounters(Counter[] counters)
        {
            foreach (Counter c in counters)
            {
                Console.WriteLine($"{c.Name} is {c.Ticks}");
            }
        }

        static void Main(string[] args)
        {
            Counter[] myCounters = new Counter[5];
            myCounters[0] = new Counter("Counter 1");
            myCounters[1] = new Counter("Counter 2");
            myCounters[2] = new Counter("Counter 3");
            myCounters[3] = new Counter("Counter 4");
            myCounters[4] = new Counter("Counter 5");

            PrintCounters(myCounters);

            myCounters = null;
            myCounters[4].Name = "Minh An Nguyen - 104844794";

            PrintCounters(myCounters);
        }
    }
}