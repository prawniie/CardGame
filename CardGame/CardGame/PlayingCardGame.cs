using System;
using System.Collections.Generic;

namespace CardGame
{
    class PlayingCardGame
    {

        public void Menu()
        {

            //Ska innehålla minst en instans av playingcarddeck

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

            //Skapa en instans av playingcarddeck

            PlayingCardDeck playingCardDeck = new PlayingCardDeck();
            playingCardDeck.CreateDeck();

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
