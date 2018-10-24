using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameLib.Models {
    public class Deck {
        private static Random random = new Random();

        private List<Card> cards = new List<Card>();

        //public operator []

        public Deck(bool withJoker = false) {
            foreach (Suit suit in Enum.GetValues(typeof(Suit))) {
                foreach (Face face in Enum.GetValues(typeof(Face))) {
                    if (face != Face.JOKER) {
                        cards.Add(new Card(suit, face));
                    }
                }
            }
            if (withJoker) {
                cards.Add(new Card(Suit.HEARTS, Face.JOKER));
                cards.Add(new Card(Suit.SPADES, Face.JOKER));
            }
            Shuffle();
        }
        
        public void Shuffle() {
            List<Card> holder = new List<Card>();
            while (cards.Count != 0) {
                int index = random.Next(cards.Count);
                Card removedCard = cards[index];
                cards.Remove(removedCard);
                holder.Add(removedCard);
            }
        }
    }
}
