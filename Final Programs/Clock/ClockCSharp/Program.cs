using System;
using System.Diagnostics;

namespace ClockProgram
{
    public static class Program
    {
        public static void RunClock(int seconds)
        {
            Clock clock = new Clock();

            for (int i = 0; i < seconds; i++)
            {
                clock.Tick();
            }
        }

        public static void Main()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            RunClock(104844794);

            stopwatch.Stop();

            TimeSpan ts = stopwatch.Elapsed;
            Console.WriteLine("C# Clock - Minh An Nguyen - 104844794\n");
            Console.WriteLine($"Time elapsed: {ts.Microseconds:n0} microseconds");

            //Get the current process
            Process proc = Process.GetCurrentProcess();

            //Display the total physical memory size allocated for the current process 
            Console.WriteLine($"Current physical memory usage: {proc.WorkingSet64:n0} bytes");

            // Display peak memory statistics for the process.
            Console.WriteLine($"Peak physical memory usage {proc.PeakWorkingSet64:n0} bytes");
        }
    }
}