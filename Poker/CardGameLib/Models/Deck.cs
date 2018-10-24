using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameLib.Models {
    class Deck : List<Card> {
        public Deck(bool withJoker = false) {
            foreach (Suit suit in Enum.GetValues(typeof(Suit))) {
                foreach (Face face in Enum.GetValues(typeof(Face))) {
                    this.Add(new Card(suit, face));
                }
            }
        }
    }
}
