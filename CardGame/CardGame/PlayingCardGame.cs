﻿using System;
using System.Collections.Generic;

namespace CardGame
{
    class PlayingCardGame
    {

        public void Menu()
        {

            WelcomeUser();

            while (true)
            {
                Console.Clear();
                WriteMenu();

                string input = Console.ReadLine();

                if (input == "4")
                {
                    break;
                }

                switch (input)
                {
                    case "1":
                        PlayGame();
                        break;
                    case "2":
                        ShowRules();
                        break;
                    case "3":
                        ShowStatistics();
                        break;

                    default:
                        Console.WriteLine("Please write 1,2,3 or 4 to choose a menu option.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }

            Console.WriteLine("Ending game...");
        }

        public void WelcomeUser()
        {
            Console.ForegroundColor = ConsoleColor.Green;

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
            Console.Clear();

            //Skapar en ny kortlek
            PlayingCardDeck playingCardDeck = new PlayingCardDeck();
            List<PlayingCard> cards = playingCardDeck.CreateDeck();
            playingCardDeck.Shuffle(cards); //Har nu skapat en kortlek med randomiserad ordning i

            while (cards.Count >= 2)
            {
                Console.WriteLine("\nWrite 'h' for higher and 'l' for lower. Write 'exit' to go back to main menu");
                Console.WriteLine("_____________________________________________________________________________");

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
                    if (answer.ToLower() == "l")
                    {
                        WriteGreen("your answer was correct!\n");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else if(answer.ToLower() == "h")
                    {
                        WriteRed("your answer was wrong!\n");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("I didn't quite get that. Please write 'h' or 'l'");
                        Console.ReadKey();
                        Console.Clear();
                    }

                }
                else if (firstCard.Value < secondCard.Value)
                {
                    if (answer.ToLower() == "h")
                    {
                        WriteGreen("your answer was correct!\n");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else if (answer.ToLower() == "l")
                    {
                        WriteRed("your answer was wrong!\n");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("I didn't quite get that. Please write 'h' or 'l'");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                else
                {
                    WriteGreen("The cards have the same value!\n");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            //playingCardDeck.AddCardToBottomOfDeck();

        }

        public void ShowRules()
        {
            Console.WriteLine("Some rules..");
            Console.ReadKey();

            //Write exit to go back to main menu
        }

        public void ShowStatistics()
        {
            Console.WriteLine("Some statistics..");
            Console.ReadKey();

            //Write exit to go back to main menu

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

        public void WriteMenu()
        {
            Console.WriteLine();
            Console.WriteLine("███╗   ███╗███████╗███╗   ██╗██╗   ██╗");
            Console.WriteLine("████╗ ████║██╔════╝████╗  ██║██║   ██║");
            Console.WriteLine("██╔████╔██║█████╗  ██╔██╗ ██║██║   ██║");
            Console.WriteLine("██║╚██╔╝██║██╔══╝  ██║╚██╗██║██║   ██║");
            Console.WriteLine("██║ ╚═╝ ██║███████╗██║ ╚████║╚██████╔╝");
            Console.WriteLine("╚═╝     ╚═╝╚══════╝╚═╝  ╚═══╝ ╚═════╝ ");
            Console.WriteLine();

            Console.WriteLine("1) Play new game");
            Console.WriteLine("2) Rules");
            Console.WriteLine("3) Statistics");
            Console.WriteLine("4) Exit");
        }

    }
}
