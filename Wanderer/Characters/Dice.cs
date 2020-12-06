using System;
using System.Collections.Generic;
using System.Text;

namespace Wanderer.Characters
{
    class Dice
    {
        protected Random random;
        public Dice(Random random)
        {
            this.random = random;
        }

        public int Roll() => random.Next(1, 7);
    }
}
