using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    class PlayingCardGame
    {

        public void Menu()
        {
            WelcomeUser();
            PlayGame();
            ShowRules();
            ShowStatistics();
            EndGame();
        }

        public void WelcomeUser()
        {
            Console.WriteLine("Welcome to this fantastic game..");
        }

        public void PlayGame()
        {
            Console.WriteLine("Playing new game..");
        }

        public void ShowRules()
        {
            Console.WriteLine("Some rules..");
        }

        public void ShowStatistics()
        {
            Console.WriteLine("Some statistics..");
        }

        public void EndGame()
        {
            Console.WriteLine("Ending game..");
        }

    }
}
