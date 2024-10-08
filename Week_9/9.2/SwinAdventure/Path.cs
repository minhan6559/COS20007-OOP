using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Path : GameObject
    {
        private Location _source, _destination;
        private bool _isBlocked;

        public Path(string[] ids, string name, string desc, Location source, Location destination) : base(ids, name, desc)
        {
            _source = source;
            _destination = destination;
            _isBlocked = false;
        }

        public bool IsBlocked
        {
            get
            {
                return _isBlocked;
            }
            set
            {
                _isBlocked = value;
            }
        }

        public Location Source
        {
            get
            {
                return _source;
            }
        }

        public Location Destination
        {
            get
            {
                return _destination;
            }
        }
    }
}