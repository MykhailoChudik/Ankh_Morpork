using System;
using System.Collections.Generic;
using System.Text;

namespace Ankh_Morpork
{
    public interface IAchievements
    {
        void Update(IGame game, int type);
    }

    class Achievements : IAchievements
    {
        private bool _goldAchievement = false;
        private int _countFool = 0;
        private int _countBeggary = 0;
        private int _countAssassin = 0;
        private int _countThieves = 0;


        public void Update(IGame game, int type)
        {
            switch (type)
            {
                case -1:
                    GoldAchievement(game);
                    break;
                case 0:
                    FoolsAchievement(game);
                    break;
                case 1:
                    BeggaryAchievement(game);
                    break;
                case 2:
                    AssassinAchievement(game);
                    break;
                case 3:
                    ThievesAchievement(game);
                    break;
                default:
                    break;
            }
        }

        private void GoldAchievement(IGame game)
        {
            if ((game as Game).gold >= 20000 && !_goldAchievement)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Achievement unlock: Reach 200 dollars. Price == 20 dollars");
                Console.ResetColor();
                _goldAchievement = true;
            }
        }

        private void FoolsAchievement(IGame game)
        {
            this._countFool++;
            switch (_countFool)
            {
                case 1:
                    Message(1, "Fools", 5);
                    (game as Game).gold += 500;
                    break;
                case 5:
                    Message(5, "Fools", 10);
                    (game as Game).gold += 1000;
                    break;
                case 10:
                    Message(10, "Fools", 15);
                    (game as Game).gold += 1500;
                    break;
                default:
                    break;
            }
        }

        private void BeggaryAchievement(IGame game)
        {
            this._countBeggary++;
            switch (_countBeggary)
            {
                case 1:
                    Message(1, "Beggary", 5);
                    (game as Game).gold += 500;
                    break;
                case 5:
                    Message(5, "Beggary", 10);
                    (game as Game).gold += 1000;
                    break;
                case 10:
                    Message(10, "Beggary", 15);
                    (game as Game).gold += 1500;
                    break;
                default:
                    break;
            }
        }

        private void AssassinAchievement(IGame game)
        {
            this._countAssassin++;
            switch (_countAssassin)
            {
                case 1:
                    Message(1, "Assassin", 5);
                    (game as Game).gold += 500;
                    break;
                case 5:
                    Message(5, "Assassin", 10);
                    (game as Game).gold += 1000;
                    break;
                case 10:
                    Message(10, "Assassin", 15);
                    (game as Game).gold += 1500;
                    break;
                default:
                    break;
            }
        }

        private void ThievesAchievement(IGame game)
        {
            this._countThieves++;
            switch (_countThieves)
            {
                case 1:
                    Message(1, "Thieves", 5);
                    (game as Game).gold += 500;
                    break;
                case 3:
                    Message(3, "Thieves", 10);
                    (game as Game).gold += 1000;
                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Achievement unlock: Meet all Thieves. Price == 15 dollars");
                    Console.ResetColor();
                    (game as Game).gold += 1500;
                    break;
                default:
                    break;
            }
        }

        private void Message(int n, string name, int price)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Achievement unlock: Meet {n} {name}  Price == {price} dollars");
            Console.ResetColor();
        }
    }
}
