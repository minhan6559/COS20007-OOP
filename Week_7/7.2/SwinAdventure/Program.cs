namespace SwinAdventure
{
    class Program
    {
        static void Main()
        {
            string playerName, playerDesc;
            while (true)
            {
                Console.Write("Enter player name: ");
                playerName = Console.ReadLine() ?? string.Empty;
                Console.Write("Enter player description: ");
                playerDesc = Console.ReadLine() ?? string.Empty;
                if (string.IsNullOrEmpty(playerName) || string.IsNullOrEmpty(playerDesc))
                {
                    Console.WriteLine("Player name and description cannot be empty.");
                }
                else
                {
                    break;
                }
            }
            Player player = new Player(playerName, playerDesc);

            Item item1 = new Item(new string[] { "shovel" }, "a shovel", "a wooden shovel");
            Item item2 = new Item(new string[] { "sword" }, "a sword", "a steel sword");
            player.Inventory.Put(item1);
            player.Inventory.Put(item2);

            Bag bag = new Bag(new string[] { "bag" }, "a bag", "a leather bag");
            player.Inventory.Put(bag);

            Item item3 = new Item(new string[] { "coin" }, "a coin", "a shiny coin");
            bag.Inventory.Put(item3);
            LookCommand look = new LookCommand();

            while (true)
            {
                Console.WriteLine(player.FullDescription);
                Console.Write("> ");
                string command = Console.ReadLine() ?? string.Empty;

                if (string.IsNullOrEmpty(command))
                    continue;
                if (command == "quit")
                    break;

                string response = look.Execute(player, command.Split(" "));
                Console.WriteLine(response);
                Console.WriteLine();
            }
        }
    }
}