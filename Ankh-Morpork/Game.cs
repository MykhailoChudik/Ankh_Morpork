using System;
using System.Collections.Generic;
using System.Text;

namespace Ankh_Morpork
{
    public class Game
    {
        private bool alive;
        private byte thiefs;
        private int gold;

        private Fools fools;
        private Beggary beggary;
        private Assassins assasins;
        
        public Game()
        {
            this.alive = true;
            this.thiefs = 6;
            this.gold = 10000;
            this.fools = new Fools();
            this.beggary = new Beggary();
            this.assasins = new Assassins();
        }

        public void Play()
        {
            while (alive && gold > 0)
            {
                Console.WriteLine($"You current balance {gold / 100} dollars {gold % 100} pence");
                var thief = thiefs > 0 ? 4 : 3;
                var situation = GetRandomNumber(thief);
                
                switch (situation)
                {
                    case 0:
                        MeetFools();
                        break;
                    case 1:
                        MeetBeggary();
                        break;
                    case 2:
                        MeetAssassins();
                        break;
                    case 3:
                        MeetThieves();
                        break;
                }
            }
            if (!alive || gold <= 0)
                Console.WriteLine("You lose");
        }

        private int GetRandomNumber(int n)
        {
            var num = new Random();

            return num.Next(0, n);
        }

        private void MeetFools()
        {
            Console.WriteLine("You meet the guild of Fools and Joculators and College of Clowns");
            var price = fools.GetFoolPrice();
            Console.WriteLine($"Put:\n" +
                              $"1 for \"Play\"\n" +
                              $"2 for\"Skip\"");
            var answer = Console.ReadLine();

            if (String.Compare(answer, "1", StringComparison.OrdinalIgnoreCase) == 0)
                gold = Plus(gold, price);
            else
                Console.WriteLine("You skip proposition");
        }

        private void MeetBeggary()
        {
            Console.WriteLine("You meet Ankh-Morpork Beggars' Guild");
            var price = beggary.GetBeggaryPrice();
            Console.WriteLine($"Put:\n" +
                              $"1 for \"Give alms\"\n" +
                              $"2 for \"Skip\"");
            var answer = Console.ReadLine();

            if (String.Compare(answer, "1", StringComparison.OrdinalIgnoreCase) == 0)
                gold = Minus(gold, price);
            else
            {
                Console.WriteLine("You will be chased to death");
                alive = false;
            }
        }

        private void MeetAssassins()
        {
            Console.WriteLine("You meet Ankh-Morpork Assassins' Guild");
            Console.WriteLine($"Someone wants to kill you\n" +
                              $"Put:\n" +
                              $"1 for \"Create contract\"\n" +
                              $"2 for \"Skip\"");
            var answer = Console.ReadLine();

            if (String.Compare(answer, "1", StringComparison.OrdinalIgnoreCase) == 0)
            {
                Console.WriteLine("Input the reward in dollars");
                var revardStr = Console.ReadLine();
                var revard = int.Parse(revardStr) * 100;
                if (assasins.AssassinAcceptContract(revard))
                    gold = Minus(gold, revard);
                else
                {
                    Console.WriteLine("Any assassin does not take the contract\nYou will be murdered");
                    alive = false;
                }
            }
            else
            {
                Console.WriteLine("You will be murdered");
                alive = false;
            }
        }

        private void MeetThieves()
        {
            Console.WriteLine("You meet guild of Thieves, Cutpurses and Allied Trades");
            Console.WriteLine($"Put:\n" +
                              $"1 for \"Give money (10 dollars)\"\n" +
                              $"2 for \"Give up\"");
            var answer = Console.ReadLine();

            if (String.Compare(answer, "1", StringComparison.OrdinalIgnoreCase) == 0)
                gold = Minus(gold, 1000);
            else
            {
                Console.WriteLine("Game over");
                alive = false;
            }

            thiefs--;
        }

        //Method Plus created only because I need something to test
        public int Plus(int a, int b) => a + b;

        //Method Minus created with similarly reason which Plus
        public int Minus(int a, int b) => a - b;
    }
}
