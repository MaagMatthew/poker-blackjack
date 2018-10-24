using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameLib.Models {
    public class Card {
        public Suit Suit { get; set; }
        public Face Face { get; set; }
        
        public Card(Suit suit, Face face) {
            Suit = suit;
            Face = face;
        }
    }
    public enum Suit {
        HEARTS,
        DIAMONDS,
        CLUBS,
        SPADES
    }
    public enum Face {
        ACE,
        TWO,
        THREE,
        FOUR,
        FIVE,
        SIX,
        SEVEN,
        EIGHT,
        NINE,
        TEN,
        JACK,
        QUEEN,
        KING,
        JOKER
    }
}