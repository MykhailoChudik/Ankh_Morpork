using System;
using System.Collections.Generic;

namespace Ankh_Morpork
{
    class Beggary
    {
        public Dictionary<int, Person> beggary = new Dictionary<int, Person>();

        public Beggary()
        {
            SetBeggaryInDictionary();
        }

        private void SetBeggaryInDictionary()
        {
            this.beggary.Add(0, new Person("Twitchers", 300));
            this.beggary.Add(1, new Person("Droolers", 200));
            this.beggary.Add(2, new Person("Dribblers", 100));
            this.beggary.Add(3, new Person("Mumblers", 100));
            this.beggary.Add(4, new Person("Mutterers", 90));
            this.beggary.Add(5, new Person("Walking - Along - Shouters", 80));
            this.beggary.Add(6, new Person("Demanders of a Chip", 60));
            this.beggary.Add(7, new Person("People Who Call Other People Jimmy", 50));
            this.beggary.Add(8, new Person("People Who Need Eightpence For A Meal", 8));
            this.beggary.Add(9, new Person("People Who Need Tuppence For A Cup Of Tea", 2));
            this.beggary.Add(10, new Person("People With Placards Saying \"Why lie ? I need a beer\"", 0));
        }

        public int GetBeggaryPrice()
        {
            var random = new Random();
            var rndBeggary = random.Next(0, 11);
            
            Console.WriteLine($"You meet {beggary[rndBeggary].name}.\n" +
                              $"He asks for {beggary[rndBeggary].price / 100} " +
                              $"dollars {beggary[rndBeggary].price % 100} pence.");
            return beggary[rndBeggary].price;
        }
    }
}
