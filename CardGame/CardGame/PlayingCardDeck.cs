using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CardGame
{
    public class PlayingCardDeck
    {

        public void CreateDeck()
        {
            //Skapa en blandad!! kortlek som spelet ska använda sig av

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

            //All cards in the deck =)
            //foreach (var card in cards)
            //{
            //    Console.WriteLine($"{card.Suit} {card.Value}");
            //}

        }

        //Får inte randomiseringen att fungera.. första kortet kommer vara hjärter ess som tas från leken
        public static void Shuffle<T>(List<PlayingCard> cards, Random rnd)
        {
            for (var i = 0; i < cards.Count; i++)
                cards.Swap(i, rnd.Next(i, cards.Count));
        }

        public static void Swap<T>(List<PlayingCard> cards, int i, int j)
        {
            var temp = cards[i];
            cards[i] = cards[j];
            cards[j] = temp;
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

            List<PlayingCard> cardsWithCardAddedToBottom = cards;
            cardsWithCardAddedToBottom.Add(card);

            return cardsWithCardAddedToBottom;
            
        }

    }
}
