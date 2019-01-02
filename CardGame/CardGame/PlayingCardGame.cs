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
            Console.ForegroundColor = ConsoleColor.Green;
            //Console.WriteLine("   ▄█    █▄     ▄█     ▄██████▄     ▄█    █▄       ▄████████    ▄████████       ▄██████▄     ▄████████       ▄█        ▄██████▄   ▄█     █▄     ▄████████    ▄████████ ");
            //Console.WriteLine("  ███    ███   ███    ███    ███   ███    ███     ███    ███   ███    ███      ███    ███   ███    ███      ███       ███    ███ ███     ███   ███    ███   ███    ███ ");
            //Console.WriteLine("  ███    ███   ███▌   ███    █▀    ███    ███     ███    █▀    ███    ███      ███    ███   ███    ███      ███       ███    ███ ███     ███   ███    █▀    ███    ███ ");
            //Console.WriteLine(" ▄███▄▄▄▄███▄▄ ███▌  ▄███         ▄███▄▄▄▄███▄▄  ▄███▄▄▄      ▄███▄▄▄▄██▀      ███    ███  ▄███▄▄▄▄██▀      ███       ███    ███ ███     ███  ▄███▄▄▄      ▄███▄▄▄▄██▀ ");
            //Console.WriteLine("▀▀███▀▀▀▀███▀  ███▌ ▀▀███ ████▄  ▀▀███▀▀▀▀███▀  ▀▀███▀▀▀     ▀▀███▀▀▀▀▀        ███    ███ ▀▀███▀▀▀▀▀        ███       ███    ███ ███     ███ ▀▀███▀▀▀     ▀▀███▀▀▀▀▀   ");
            //Console.WriteLine("  ███    ███   ███    ███    ███   ███    ███     ███    █▄  ▀███████████      ███    ███ ▀███████████      ███       ███    ███ ███     ███   ███    █▄  ▀███████████ ");
            //Console.WriteLine("  ███    ███   ███    ███    ███   ███    ███     ███    ███   ███    ███      ███    ███   ███    ███      ███▌    ▄ ███    ███ ███ ▄█▄ ███   ███    ███   ███    ███ ");
            //Console.WriteLine("  ███    █▀    █▀     ████████▀    ███    █▀      ██████████   ███    ███       ▀██████▀    ███    ███      █████▄▄██  ▀██████▀   ▀███▀███▀    ██████████   ███    ███ ");
            //Console.WriteLine("                                                               ███    ███                   ███    ███      ▀                                               ███    ███ ");

            Console.WriteLine("██╗  ██╗██╗ ██████╗ ██╗  ██╗███████╗██████╗      ██████╗ ██████╗     ██╗      ██████╗ ██╗    ██╗███████╗██████╗ ");
            Console.WriteLine("██║  ██║██║██╔════╝ ██║  ██║██╔════╝██╔══██╗    ██╔═══██╗██╔══██╗    ██║     ██╔═══██╗██║    ██║██╔════╝██╔══██╗");
            Console.WriteLine("███████║██║██║  ███╗███████║█████╗  ██████╔╝    ██║   ██║██████╔╝    ██║     ██║   ██║██║ █╗ ██║█████╗  ██████╔╝");
            Console.WriteLine("██╔══██║██║██║   ██║██╔══██║██╔══╝  ██╔══██╗    ██║   ██║██╔══██╗    ██║     ██║   ██║██║███╗██║██╔══╝  ██╔══██╗");
            Console.WriteLine("██║  ██║██║╚██████╔╝██║  ██║███████╗██║  ██║    ╚██████╔╝██║  ██║    ███████╗╚██████╔╝╚███╔███╔╝███████╗██║  ██║");
            Console.WriteLine("╚═╝  ╚═╝╚═╝ ╚═════╝ ╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝     ╚═════╝ ╚═╝  ╚═╝    ╚══════╝ ╚═════╝  ╚══╝╚══╝ ╚══════╝╚═╝  ╚═╝");

            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }

        public void PlayGame()
        {
            Console.WriteLine("Playing new game..");

            //Skapar en ny kortlek
            PlayingCardDeck playingCardDeck = new PlayingCardDeck();
            List<PlayingCard> cards = playingCardDeck.CreateDeck();
            playingCardDeck.Shuffle(cards); //Har nu skapat en kortlek med randomiserad ordning i

            Console.ReadLine();

            //Köra nedanstående på repeat till antalet kort är 0?

            while (cards.Count >= 2)
            {
                //Console.Clear();

                PlayingCard firstCard = playingCardDeck.PickFirstCardFromDeck(cards);

                Console.WriteLine($"\nThe card is {firstCard.Suit} {firstCard.Value}");
                cards.Remove(firstCard);

                Console.Write("Do you think the next card will be higher or lower? ");
                Console.ForegroundColor = ConsoleColor.Green;
                string answer = Console.ReadLine();
                Console.ResetColor();

                if (answer.ToLower() == "exit")
                {
                    break;
                }

                PlayingCard secondCard = playingCardDeck.PickFirstCardFromDeck(cards);
                Console.Write($"The second card is {secondCard.Suit} {secondCard.Value}, ");
                cards.Remove(secondCard);

                if (firstCard.Value > secondCard.Value)
                {
                    if (answer.ToLower() == "lower")
                        WriteGreen("your answer was correct!\n");
                    else
                        WriteRed("your answer was wrong!\n");
                }
                else if (firstCard.Value < secondCard.Value)
                {
                    if (answer.ToLower() == "higher")
                        WriteGreen("your answer was correct!\n");
                    else 
                        WriteRed("your answer was wrong!\n");
                }
                else
                {
                    WriteGreen("The cards have the same value!\n");
                }

            }

            


            Console.ReadLine();

            //playingCardDeck.AddCardToBottomOfDeck();

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

        public void WriteGreen(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(text);
            Console.ResetColor();
        }

        public void WriteRed(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(text);
            Console.ResetColor();
        }

    }
}
