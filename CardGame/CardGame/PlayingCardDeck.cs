using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CardGame
{
    public class PlayingCardDeck
    {
        //representerar en kortlek på 52 kort av typen PlayingCard

        //private PlayingCard[] cards;

        public void CreateDeck()
        {

            List<PlayingCard> cards = new List<PlayingCard>();

            var suitArray = Enum.GetValues(typeof(Suit));
            var valuesArray = Enum.GetValues(typeof(Value));

                foreach (var suit in suitArray)
                {
                    foreach (var value in valuesArray)
                    {
                        PlayingCard card = new PlayingCard();
                        card.Suit = (Suit)Enum.Parse(typeof(Suit), suit.ToString());
                        card.Value = (Value)Enum.Parse(typeof(Value), value.ToString());
                        cards.Add(card);
                    }
                }

            
            Console.ReadLine();

            foreach (var card in cards)
            {
                Console.WriteLine($"{card.Suit} {card.Value}");
            }



            //List<PlayingCard> playingCardDeck = new List<PlayingCard>();

            ////PlayingCard c1 = new PlayingCard(Suit.Clubs, Value.A2, false);
            ////PlayingCard c2 = new PlayingCard(Suit.Clubs, Value.A3, false);
            ////PlayingCard c3 = new PlayingCard(Suit.Clubs, Value.A4, false);
            ////PlayingCard c4 = new PlayingCard(Suit.Clubs, Value.A5, false);
            ////PlayingCard c5 = new PlayingCard(Suit.Clubs, Value.A6, false);

            //    //playingCardDeck.Add(c1);
            //    //playingCardDeck.Add(c2);
            //    //playingCardDeck.Add(c3);
            //    //playingCardDeck.Add(c4);
            //    //playingCardDeck.Add(c5);

            //    //Ovanstående funkar ej, alla korten blir hjärter ess???

            //    //Skapa 13 hjärterkort
            //    for (int i = 1; i <= 13; i++)
            //{
            //    PlayingCard card = new PlayingCard();
            //    card.Suit = Suit.Hearts;

            //    var valuesArray = Enum.GetValues(typeof(Value));
            //    //Suit suitValue = (Suit)Enum.Parse(typeof(Suit), valuesArray);

            //    //for (int j = 0; j < values.Length; j++)
            //    //{
            //    //    card.Value = Enum.Parse(values[j]);
            //    //}

            //    //string[] colorStrings = { "0", "2", "8", "blue", "Blue", "Yellow", "Red, Green" };
            //    //Colors colorValue = (Colors) Enum.Parse(typeof(Colors), colorString); 

            //    foreach (var value in valuesArray)
            //    {
            //        card.Value = (Value)Enum.Parse(typeof(Value), value.ToString());
            //    }

            //    playingCardDeck.Add(card);
            //}

            ////Skapa 13 spaderkort
            //for (int i = 1; i <= 13; i++)
            //{
            //    PlayingCard card = new PlayingCard();
            //    card.Suit = Suit.Spades;
            //    playingCardDeck.Add(card);
            //}

            ////Skapa 13 ruterkort
            //for (int i = 1; i <= 13; i++)
            //{
            //    PlayingCard card = new PlayingCard();
            //    card.Suit = Suit.Diamonds;
            //    playingCardDeck.Add(card);
            //}

            ////Skapa 13 klöverkort
            //for (int i = 1; i <= 13; i++)
            //{
            //    PlayingCard card = new PlayingCard();
            //    card.Suit = Suit.Clubs;
            //    playingCardDeck.Add(card);
            //}

            //int counter = 1;

            //foreach (var card in playingCardDeck)
            //{
            //    Console.WriteLine($"card {counter}: {card.Suit} {card.Value} {card.IsVisible}");
            //    counter++;
            //}

            Console.ReadKey();

        }

        public void PickFirstCardFromDeck()
        {
            //Vad ska hända om kortleken är tom?
        }

        public void AddCardToBottomOfDeck() 
        {
            //Anv push,queue eller liknande
        }

    }
}
