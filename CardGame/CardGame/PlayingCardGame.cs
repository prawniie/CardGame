using System;
using System.Collections.Generic;

namespace CardGame
{
    class PlayingCardGame
    {

        public void Menu()
        {

            WelcomeUser();
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

        public void WelcomeUser()
        {
            Console.ForegroundColor = ConsoleColor.Green;

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

            //Skapar en ny kortlek
            PlayingCardDeck playingCardDeck = new PlayingCardDeck();
            List<PlayingCard> cards = playingCardDeck.CreateDeck();
            playingCardDeck.Shuffle(cards); //Har nu skapat en kortlek med randomiserad ordning i

            while (cards.Count >= 2)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\nWrite 'h' for higher and 'l' for lower. Write 'exit' to go back to main menu ");
                Console.WriteLine("_____________________________________________________________________________");
                Console.ResetColor();

                PlayingCard firstCard = playingCardDeck.PickFirstCardFromDeck(cards);

                Console.WriteLine($"\nThe card is {firstCard.Suit} {firstCard.Value}");
                cards.Remove(firstCard);

                string answer = "";

                Console.Write("Do you think the next card will be higher or lower? ");

                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    answer = Console.ReadLine();
                    Console.ResetColor();

                    if (answer.ToLower() == "l" || answer.ToLower() == "h")
                    {
                        CompareCards(playingCardDeck, cards, firstCard, answer);
                        break;
                    }
                    else if (answer.ToLower() == "exit")
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("I didn't quite get that. Please write 'h' or 'l': ");
                        continue;
                    }
                }

                if (answer.ToLower() == "exit")
                {
                    break;
                }
                //    if (firstCard.Value > secondCard.Value)
                //    {
                //        if (answer.ToLower() == "l")
                //        {
                //            WriteGreen("your answer was correct!\n");
                //            Console.ReadKey();
                //            Console.Clear();
                //        }
                //        else if(answer.ToLower() == "h")
                //        {
                //            WriteRed("your answer was wrong!\n");
                //            Console.ReadKey();
                //            Console.Clear();
                //        }
                //        else
                //        {
                //            Console.WriteLine("I didn't quite get that. Please write 'h' or 'l'");
                //            Console.ReadKey();
                //            Console.Clear();
                //        }

                //    }
                //    else if (firstCard.Value < secondCard.Value)
                //    {
                //        if (answer.ToLower() == "h")
                //        {
                //            WriteGreen("your answer was correct!\n");
                //            Console.ReadKey();
                //            Console.Clear();
                //        }
                //        else if (answer.ToLower() == "l")
                //        {
                //            WriteRed("your answer was wrong!\n");
                //            Console.ReadKey();
                //            Console.Clear();
                //        }
                //        else
                //        {
                //            Console.WriteLine("I didn't quite get that. Please write 'h' or 'l'");
                //            Console.ReadKey();
                //            Console.Clear();
                //        }
                //    }
                //    else
                //    {
                //        WriteGreen("The cards have the same value!\n");
                //        Console.ReadKey();
                //        Console.Clear();
                //    }
            }

            //playingCardDeck.AddCardToBottomOfDeck();

        }

        private void CompareCards(PlayingCardDeck playingCardDeck, List<PlayingCard> cards, PlayingCard firstCard, string answer)
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
