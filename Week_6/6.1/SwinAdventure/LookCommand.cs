using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] { "look" })
        {
        }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length != 3 && text.Length != 5)
                return "I don't know how to look like that";

            if (text[0] != "look")
                return "Error in look input";

            if (text[1] != "at")
                return "What do you want to look at?";

            if (text.Length == 5 && text[3] != "in")
                return "What do you want to look in?";

            string containerId = "";
            if (text.Length == 3)
                containerId = p.FirstId;
            else if (text.Length == 5)
                containerId = text[4];

            IHaveInventory? container = FetchContainer(p, containerId);
            if (container == null)
                return $"I can't find the {containerId}";

            return LookAtIn(text[2], container);
        }

        public IHaveInventory? FetchContainer(Player p, string containerId)
        {
            return p.Locate(containerId) as IHaveInventory;
        }

        public string LookAtIn(string thingId, IHaveInventory container)
        {
            GameObject? thing = container.Locate(thingId);
            if (thing == null)
                return $"I can't find the {thingId}";

            return thing.FullDescription;
        }
    }
}