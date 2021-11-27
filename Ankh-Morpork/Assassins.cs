using System;
using System.Collections.Generic;

namespace Ankh_Morpork
{
    class Assassins
    {
        public Dictionary<int, Assassin> assassins = new Dictionary<int, Assassin>();

        public Assassins()
        {
            SetAssassinsInDictionary();
        }

        private void SetAssassinsInDictionary()
        {
            this.assassins.Add(0, new Assassin("Assasin 1", 1500, 3000, true));
            this.assassins.Add(1, new Assassin("Assasin 2", 1000, 2000, false));
            this.assassins.Add(2, new Assassin("Assasin 3", 700, 1200, false));
            this.assassins.Add(3, new Assassin("Assasin 4", 1500, 1900, true));
            this.assassins.Add(4, new Assassin("Assasin 5", 1300, 1300, false));
            this.assassins.Add(5, new Assassin("Assasin 6", 600, 1300, true));
            this.assassins.Add(6, new Assassin("Assasin 7", 1700, 2200, false));
            this.assassins.Add(7, new Assassin("Assasin 8", 2400, 2700, true));
        }

        public bool AssassinAcceptContract(int revard)
        {
            foreach (var assassin in assassins)
            {
                if (assassin.Value.price <= revard && revard <= assassin.Value.maxPrice && assassin.Value.occupied)
                {
                    Console.WriteLine($"Your create contract which {assassin.Value.name}");
                    ReShuffle();
                    return true;
                }
            }
            ReShuffle();
            return false;
        }

        private void ReShuffle()
        {
            foreach (var assassin in assassins)
            {
                assassin.Value.Shuffle();
            }
        }
    }
}
