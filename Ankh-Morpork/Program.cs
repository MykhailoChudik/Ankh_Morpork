using System;

namespace Ankh_Morpork
{
    class Program
    {
        static void Main(string[] args)
        {

            Game game = new Game();

            Console.WriteLine("Put \"play\" for start game");
            string answer = Console.ReadLine();

            if (String.Compare(answer, "play", StringComparison.OrdinalIgnoreCase) == 0)
                game.Play();
            else
                Console.WriteLine("Goodbye");
        }
    }
}
