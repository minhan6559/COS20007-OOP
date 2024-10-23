using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] { "move", "go" })
        {
        }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length != 2 && text.Length != 3)
                return "I don't know how to move like that";

            if (text[0] != "move" && text[0] != "go")
                return "Error in move input";

            if (text.Length == 3 && text[1] != "to")
                return "Where do you want to go?";

            string destinationId = "";
            switch (text.Length)
            {
                case 2:
                    destinationId = text[1];
                    break;
                case 3:
                    destinationId = text[2];
                    break;
            }

            Path? path = p!.Locate(destinationId) as Path;
            if (path == null)
                return $"I can't find the path to {destinationId}";

            if (path.IsBlocked)
                return $"The path to {destinationId} is blocked";

            p.Location = path.Destination;
            return $"You have moved to {path.Destination.Name}";
        }
    }
}