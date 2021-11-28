using System;
using System.Collections.Generic;
using System.Text;

namespace Ankh_Morpork
{
    //For achievements
    public interface IGame
    {
        void Attach(IAchievements achievements);

        void Notify();

        void Notify(int type);
    }

    public class Game : IGame
    {
        private bool alive;
        private byte thiefs;
        public int gold { get; set; }

        private Fools fools;
        private Beggary beggary;
        private Assassins assasins;
        //achievements
        private List<IAchievements> _achievements;

        public Game()
        {
            this.alive = true;
            this.thiefs = 6;
            this.gold = 10000;
            this.fools = new Fools();
            this.beggary = new Beggary();
            this.assasins = new Assassins();
            this._achievements = new List<IAchievements>();
        }

        public void Play()
        {
            Attach(new Achievements());

            while (alive && gold > 0)
            {
                Balance();
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

        private void Balance()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"You current balance {gold / 100} dollars {gold % 100} pence");
            Console.ResetColor();
            Notify();
        }

        private int GetRandomNumber(int n)
        {
            var num = new Random();

            return num.Next(0, n);
        }

        private void MeetFools()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("You meet the guild of Fools and Joculators and College of Clowns");
            Console.ResetColor();
            var price = fools.GetFoolPrice();
            Console.WriteLine($"Put:\n" +
                              $"1 for \"Play\"\n" +
                              $"2 for \"Skip\"");
            var answer = Console.ReadLine();

            if (String.Compare(answer, "1", StringComparison.OrdinalIgnoreCase) == 0)
            {
                gold = Plus(gold, price);
                Notify(0);
            }
            else
                Console.WriteLine("You skip proposition");
        }

        private void MeetBeggary()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You meet Ankh-Morpork Beggars' Guild");
            Console.ResetColor();
            var price = beggary.GetBeggaryPrice();
            Console.WriteLine($"Put:\n" +
                              $"1 for \"Give alms\"\n" +
                              $"2 for \"Skip\"");
            var answer = Console.ReadLine();

            if (String.Compare(answer, "1", StringComparison.OrdinalIgnoreCase) == 0)
            {
                gold = Minus(gold, price);
                Notify(1);
            }
            else
            {
                Console.WriteLine("You will be chased to death");
                alive = false;
            }
        }

        private void MeetAssassins()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("You meet Ankh-Morpork Assassins' Guild");
            Console.ResetColor();
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
                {
                    gold = Minus(gold, revard);
                    Notify(2);
                }
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
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("You meet guild of Thieves, Cutpurses and Allied Trades");
            Console.ResetColor();
            Console.WriteLine($"Put:\n" +
                              $"1 for \"Give money (10 dollars)\"\n" +
                              $"2 for \"Give up\"");
            var answer = Console.ReadLine();

            if (String.Compare(answer, "1", StringComparison.OrdinalIgnoreCase) == 0)
            {
                gold = Minus(gold, 1000);
                Notify(3);
            }
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

        //achievements
        public void Attach(IAchievements achievements)
        {
            this._achievements.Add(achievements);
        }

        public void Notify()
        {
            foreach (var achievement in _achievements)
            {
                achievement.Update(this, -1);
            }
        }

        public void Notify(int type)
        {
            foreach (var achievement in _achievements)
            {
                achievement.Update(this, type);
            }
        }
    }
}
