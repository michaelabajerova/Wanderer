using System;
using System.Collections.Generic;
using System.Text;

namespace Wanderer.GameMap
{
    class Walkable : Map
    {
        public bool IsWalkable;

        public Walkable(bool isWalkable)
        {
            IsWalkable = isWalkable;
        }

    }
}

