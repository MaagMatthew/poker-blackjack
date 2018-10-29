using CardGameLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameLib.Models {
    public class Deck {
        private static Random random = new Random();

        private List<Card> cards = new List<Card>();

        public int Size {
            get {
                return cards.Count;
            }
        }

        public Card this[int index] {
            get {
                return cards[index];
            }
        }

        public Deck(bool isEmpty = false, bool withJoker = false) {
            if (!isEmpty) {
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
        }
        
        public void Shuffle() {
            List<Card> holder = new List<Card>();
            while (cards.Count != 0) {
                holder.Add(Remove(random.Next(cards.Count)));
            }
            cards = holder;
        }

        public Card Remove(int index) {
            Card result = cards[index];
            cards.Remove(result);
            return result;
        }

        public void Return(Card card) {
            cards.Add(card);
        }

        public Card Draw() {
            return Remove(0);
        }

        public List<Card> GetCards()
        {
            return cards;
        }

        public int FaceCount(Face face) {
            int count = 0;
            foreach (Card card in cards) {
                if (card.Face == face) {
                    count++;
                }
            }
            return count;
        }
        public int SuitCount(Suit suit) {
            int count = 0;
            foreach (Card card in cards) {
                if (card.Suit == suit) {
                    count++;
                }
            }
            return count;
        }
        public bool Contains(Card card) {
            foreach (Card loopCard in cards) {
                if (card == loopCard) {
                    return true;
                }
            }
            return false;
        }
    }
}
