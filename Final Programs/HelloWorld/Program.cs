namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Message myMessage = new Message("Hello, World! Greetings from Message Object. My Student ID is 104844794");
            myMessage.Print();

            Message[] messages =
            {
                new Message("Hi Andrew, how are you?"),
                new Message("Hi Andy, how are you?"),
                new Message("Hi Peter, how are you?"),
                new Message("Welcome Admin"),
                new Message("Welcome, nice to me you.")
            };

            while (true)
            {
                Console.Write("Enter name: ");
                string name = Console.ReadLine();
                if (name.ToLower() == "exit")
                {
                    Console.WriteLine("Bye");
                    break;
                }

                switch (name.ToLower())
                {
                    case "andrew":
                        messages[0].Print();
                        break;
                    case "andy":
                        messages[1].Print();
                        break;
                    case "peter":
                        messages[2].Print();
                        break;
                    case "an":
                        messages[3].Print();
                        break;
                    default:
                        messages[4].Print();
                        break;
                }
            }
        }
    }
}