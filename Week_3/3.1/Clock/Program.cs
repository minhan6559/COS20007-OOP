namespace ClockProgram
{
    public static class Program
    {
        public static void Main()
        {
            Clock clock = new Clock();

            for (int i = 0; i < 5; i++)
            {
                clock.Tick();
                System.Console.WriteLine(clock.Time);
            }
        }
    }
}