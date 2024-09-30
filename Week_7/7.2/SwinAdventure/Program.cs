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

            // Create items and put them in the player's inventory
            Item item1 = new Item(new string[] { "shovel" }, "a shovel", "a wooden shovel");
            Item item2 = new Item(new string[] { "sword" }, "a sword", "a steel sword");
            player.Inventory.Put(item1);
            player.Inventory.Put(item2);

            // Create a bag and put it in the player's inventory
            Bag bag = new Bag(new string[] { "bag" }, "a bag", "a leather bag");
            player.Inventory.Put(bag);

            // Create items and put them in the bag's inventory
            Item item3 = new Item(new string[] { "coin" }, "a coin", "a shiny coin");
            bag.Inventory.Put(item3);

            // Create location and put some items in its inventory
            Location location = new Location("forest", "A dark forest with tall trees");
            Item item4 = new Item(new string[] { "rock" }, "a rock", "a big rock");
            Item item5 = new Item(new string[] { "flower" }, "a flower", "a red flower");
            location.Inventory.Put(item4);
            location.Inventory.Put(item5);

            // Set player's location
            player.Location = location;

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