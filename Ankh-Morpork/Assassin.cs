using System;

namespace Ankh_Morpork
{
    class Assassin : Person
    {
        public int maxPrice { get; private set; }
        public bool occupied { get; private set; }

        public Assassin(string name, int min, int max, bool occupied) : base(name, min)
        {
            this.maxPrice = max;
            this.occupied = occupied;
        }

        public Assassin Shuffle()
        {
            var random = new Random();
            this.occupied = random.Next(0, 2) == 0 ? false : true;

            return this;
        }
    }
}
