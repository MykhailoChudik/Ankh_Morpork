using System;
using System.Collections.Generic;

namespace Ankh_Morpork
{
    class Fools
    {
        public Dictionary<int, Person> fools = new Dictionary<int, Person>();

        public Fools()
        {
            SetFoolsInDictionary();
        }

        private void SetFoolsInDictionary()
        {
            this.fools.Add(0, new Person("Muggins", 50));
            this.fools.Add(1, new Person("Gull", 100));
            this.fools.Add(2, new Person("Dupe", 200));
            this.fools.Add(3, new Person("Butt", 300));
            this.fools.Add(4, new Person("Fool", 500));
            this.fools.Add(5, new Person("Tomfool", 600));
            this.fools.Add(6, new Person("Stupid Fool", 700));
            this.fools.Add(7, new Person("Arch Fool", 800));
            this.fools.Add(8, new Person("Complete Fool", 1000));
        }

        public int GetFoolPrice()
        {
            var num = new Random();
            var randomFool = num.Next(0, 9); ;

            Console.WriteLine($"You meet {fools[randomFool].name}.\n" +
                              $"You can reach {fools[randomFool].price / 100} " +
                              $"dollars {fools[randomFool].price % 100} pence.");
            return fools[randomFool].price; ;
        }
    }
}
