using System;
using System.Collections.Generic;

namespace CardGame
{
    class PlayingCardGame
    {

        public void Menu()
        {

            PrintHigherOrLower();
            ShowMenu();

            Console.WriteLine("Ending game...");

            //To do 1: fixa en score för varje spelomgång som ska lagras i textfil som läses in, när man väljer menyvalet statistik
            //To do 2: fixa så att spelardata används, skapa klass? lagra användarnamn och statistik
            //Lägg till: Om korten har samma valör jämför man färg där spader (♠) > hjärter (♥) > ruter (♦) > klöver (♣). 

            //Att implementera: 
            //Efter ett parti ska bägge korten stoppas tillbaka längst bak i kortleken och man ska bli tillfrågad om man vill spela ett nytt parti eller gå tillbaka till huvudmenyn. 
            //När man spelat ett spel ska ens poängställning (antal vinter/förluster) skrivas ner till fil och uppdatera sin spelarstatus-historik (totala vinster/förluster).

        }

        public void ShowMenu()
        {
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
        }

        public void PrintHigherOrLower()
        {
            Console.WriteLine();
            Console.WriteLine(" ██╗  ██╗██╗ ██████╗ ██╗  ██╗███████╗██████╗      ██████╗ ██████╗     ██╗      ██████╗ ██╗    ██╗███████╗██████╗ ");
            Console.WriteLine(" ██║  ██║██║██╔════╝ ██║  ██║██╔════╝██╔══██╗    ██╔═══██╗██╔══██╗    ██║     ██╔═══██╗██║    ██║██╔════╝██╔══██╗");
            Console.WriteLine(" ███████║██║██║  ███╗███████║█████╗  ██████╔╝    ██║   ██║██████╔╝    ██║     ██║   ██║██║ █╗ ██║█████╗  ██████╔╝");
            Console.WriteLine(" ██╔══██║██║██║   ██║██╔══██║██╔══╝  ██╔══██╗    ██║   ██║██╔══██╗    ██║     ██║   ██║██║███╗██║██╔══╝  ██╔══██╗");
            Console.WriteLine(" ██║  ██║██║╚██████╔╝██║  ██║███████╗██║  ██║    ╚██████╔╝██║  ██║    ███████╗╚██████╔╝╚███╔███╔╝███████╗██║  ██║");
            Console.WriteLine(" ╚═╝  ╚═╝╚═╝ ╚═════╝ ╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝     ╚═════╝ ╚═╝  ╚═╝    ╚══════╝ ╚═════╝  ╚══╝╚══╝ ╚══════╝╚═╝  ╚═╝");

            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }

        public void PlayGame()
        {
            Console.Clear();

            string userName = AskUserForName();
            WelcomeUser(userName);
            int score = 0;

            //Skapar en ny kortlek
            PlayingCardDeck playingCardDeck = new PlayingCardDeck();
            List<PlayingCard> cards = playingCardDeck.CreateDeck();
            playingCardDeck.Shuffle(cards); //Har nu skapat en kortlek med randomiserad ordning i

            Console.Clear();
            while (cards.Count >= 2)
            {
                PrintInstructions("\nWrite 'h' for higher and 'l' for lower. Write 'exit' to go back to main menu ");

                PlayingCard firstCard = playingCardDeck.PickFirstCardFromDeck(cards);

                Console.WriteLine($"\nThe card is {firstCard.Suit} {firstCard.Value}");
                cards.Remove(firstCard);

                string input = "";

                Console.Write("Do you think the next card will be higher or lower? ");

                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    input = Console.ReadLine();
                    Console.ResetColor();

                    if (input.ToLower() == "l" || input.ToLower() == "h")
                    {
                        score = CompareCards(playingCardDeck, cards, firstCard, input, score);
                        break;
                    }
                    else if (input.ToLower() == "exit")
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("I didn't quite get that. Please write 'h' or 'l': ");
                        continue;
                    }
                }

                if (input.ToLower() == "exit")
                {
                    EndGame(userName, score);
                    break;
                }
            }
        }

        private void EndGame(string userName, int score)
        {
            Console.WriteLine($"{userName} got {score} points!");
            string result = $"{userName}                {score}";
            System.IO.File.WriteAllText("highscore.txt", result);
            Console.ReadKey();
        }

        private void WelcomeUser(string userName)
        {
            Console.WriteLine($"\nWelcome {userName}!");
            Console.Write("Do you want to hear the rules before you start the game (yes/no)? ");

            while (true)
            {
                string answer = Console.ReadLine();

                if (answer.ToLower() == "yes")
                {
                    ShowRules();
                    break;
                }
                else if (answer.ToLower() == "no")
                {
                    Console.WriteLine("Okey then, let's get started!");
                    break;
                }
                else
                {
                    Console.Write("Sorry, I didn't get that. Please write yes or no: ");
                    continue;
                }
            }
        }

        private string AskUserForName()
        {
            Console.Write("Enter name: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string name = Console.ReadLine();
            Console.ResetColor();

            return name;
        }

        public void PrintInstructions(string text)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(text);
            Console.WriteLine("_____________________________________________________________________________");
            Console.ResetColor();
        }

        private int CompareCards(PlayingCardDeck playingCardDeck, List<PlayingCard> cards, PlayingCard firstCard, string answer, int score)
        {
            PlayingCard secondCard = playingCardDeck.PickFirstCardFromDeck(cards);
            Console.Write($"The second card is {secondCard.Suit} {secondCard.Value}, ");
            cards.Remove(secondCard);

            switch (answer)
            {
                case "l":
                    if (firstCard.Value > secondCard.Value)
                    {
                        WriteGreen("your answer was correct!\n");
                        score++;
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else if (firstCard.Value == secondCard.Value)
                    {
                        WriteGreen("the cards have the same value!\n");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        WriteRed("your answer was wrong!\n");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    break;

                case "h":
                    if (firstCard.Value < secondCard.Value)
                    {
                        WriteGreen("your answer was correct!\n");
                        score++;
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else if (firstCard.Value == secondCard.Value)
                    {
                        WriteGreen("the cards have the same value!\n");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        WriteRed("your answer was wrong!\n");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    break;
                default:
                    break;
            }

            return score;
        }

        public void ShowRules()
        {
            Console.Clear();
            WriteRulesHeader();
            Console.WriteLine("\n* Two cards are taken from the deck.\n  The first one is shown and the second one is given to you.");
            Console.WriteLine("\n* You are supposed to guess whether your card's value\n  is higher or lower than the visible card.");
            Console.WriteLine("\n* If you are right, you get one point. ");
            Console.WriteLine("\n* You win when you get 10 points!");

            Console.WriteLine("\n__________________________________________________________\n");
            Console.WriteLine("\nPress any key to go back to main menu");
            Console.ReadKey();
        }

        public void ShowStatistics()
        {
            Console.Clear();
            WriteHighscoreHeader();
            Console.WriteLine("  NAME                       SCORE");
            Console.WriteLine("* Some users name            XXX");
            Console.WriteLine("* Other users name           XXX");

            Console.WriteLine("\n______________________________________________________________________\n");
            Console.WriteLine("\nPress any key to go back to main menu");
            Console.ReadKey();

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
            Console.WriteLine("3) Highscore");
            Console.WriteLine("4) Exit");
        }

        public void WriteRulesHeader()
        {
            Console.WriteLine();
            Console.WriteLine(" ██████╗ ██╗   ██╗██╗     ███████╗███████╗");
            Console.WriteLine(" ██╔══██╗██║   ██║██║     ██╔════╝██╔════╝");
            Console.WriteLine(" ██████╔╝██║   ██║██║     █████╗  ███████╗");
            Console.WriteLine(" ██╔══██╗██║   ██║██║     ██╔══╝  ╚════██║");
            Console.WriteLine(" ██║  ██║╚██████╔╝███████╗███████╗███████║");
            Console.WriteLine(" ╚═╝  ╚═╝ ╚═════╝ ╚══════╝╚══════╝╚══════╝");
        }

        public void WriteHighscoreHeader()
        {
            Console.WriteLine();
            Console.WriteLine("██╗  ██╗██╗ ██████╗ ██╗  ██╗███████╗ ██████╗ ██████╗ ██████╗ ███████╗");
            Console.WriteLine("██║  ██║██║██╔════╝ ██║  ██║██╔════╝██╔════╝██╔═══██╗██╔══██╗██╔════╝");
            Console.WriteLine("███████║██║██║  ███╗███████║███████╗██║     ██║   ██║██████╔╝█████╗  ");
            Console.WriteLine("██╔══██║██║██║   ██║██╔══██║╚════██║██║     ██║   ██║██╔══██╗██╔══╝  ");
            Console.WriteLine("██║  ██║██║╚██████╔╝██║  ██║███████║╚██████╗╚██████╔╝██║  ██║███████╗");
            Console.WriteLine("╚═╝  ╚═╝╚═╝ ╚═════╝ ╚═╝  ╚═╝╚══════╝ ╚═════╝ ╚═════╝ ╚═╝  ╚═╝╚══════╝");
            Console.WriteLine();
        }

    }
}
