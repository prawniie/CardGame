using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame
{
    public class PlayingCardDeck
    {

        public List<PlayingCard> CreateDeck()
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

            return cards;

            //All cards in the deck =)
            //foreach (var card in cards)
            //{
            //    Console.WriteLine($"{card.Suit} {card.Value}");
            //}

        }

        //Bra länkar att titta på
        //http://www.tutorialsteacher.com/csharp/csharp-list

        private static Random rng = new Random();

        public void Shuffle<PlayingCard>(List<PlayingCard> cards)
        {
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                PlayingCard value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }
        }

        public PlayingCard PickFirstCardFromDeck(List<PlayingCard> cards)
        {
            if (cards.Count == 0)
            {
                Console.WriteLine("Oupps! Seems like there are no cards left.");
            }

            return cards.First();
            
        }

        public List<PlayingCard> AddCardToBottomOfDeck(List<PlayingCard> cards, PlayingCard card) 
        {

            List<PlayingCard> cardsWithCardAddedToBottom = cards; //Eller behöver man använda AddRange för att kopiera samtliga element?
            cardsWithCardAddedToBottom.Add(card);

            return cardsWithCardAddedToBottom;
            
        }

    }
}
