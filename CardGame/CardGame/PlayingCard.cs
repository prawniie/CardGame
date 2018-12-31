using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public class PlayingCard
    {
        public Suit Suit { get; set; }
        public Value Value { get; set; }
        public bool IsVisible { get; set; }


        public PlayingCard()
        {

        }

        public PlayingCard(Suit suit)
        {

        }

        public PlayingCard(Value value)
        {

        }

        public PlayingCard(Suit suit, Value value)
        {

        }

        //public PlayingCard(Suit suit, Value value, bool isVisible)
        //{

        //}
    }
}
