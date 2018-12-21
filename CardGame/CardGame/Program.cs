using System;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayingCardGame game = new PlayingCardGame();
            game.Menu();

            Console.ReadLine();
        }
    }
}
