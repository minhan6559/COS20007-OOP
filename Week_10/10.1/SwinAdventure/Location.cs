using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private List<Path> _paths;

        public Location(string name, string desc) : base(new string[] { "location", "room", "here" }, name, desc)
        {
            _inventory = new Inventory();
            _paths = new List<Path>();
        }

        public Location(string name, string desc, List<Path> paths) : this(name, desc)
        {
            _paths = paths;
        }

        public GameObject? Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }

            foreach (Path path in _paths)
            {
                if (path.AreYou(id))
                {
                    return path;
                }
            }

            return _inventory.Fetch(id);
        }

        public override string FullDescription
        {
            get
            {
                return $"You are in the {Name}.\n" +
                        $"{base.FullDescription}\n" +
                        $"{PathList}\n" +
                        $"In this location, you can see:\n{_inventory.ItemList}";
            }
        }

        public string PathList
        {
            get
            {
                if (_paths.Count == 0)
                {
                    return "There are no paths to other locations";
                }

                string paths = "There are exits to ";

                for (int i = 0; i < _paths.Count; i++)
                {
                    paths += _paths[i].Name;
                    if (i < _paths.Count - 1)
                    {
                        paths += ", ";
                    }
                }

                return paths;
            }
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

        public void AddPath(Path path)
        {
            _paths.Add(path);
        }
    }
}