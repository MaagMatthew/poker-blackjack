using CardGameLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameLib.Models {
    public class Card {
        public readonly Suit Suit;
        public readonly Face Face;
        
        public Card(Suit suit, Face face) {
            Suit = suit;
            Face = face;
        }

        private string SuitChar() {
            return Enum.GetName(typeof(Suit), Suit)[0].ToString();
        }
        private string FaceChar() {
            switch (Face) {
                case Face.ACE:
                    return "A";
                case Face.TWO:
                    return "2";
                case Face.THREE:
                    return "3";
                case Face.FOUR:
                    return "4";
                case Face.FIVE:
                    return "5";
                case Face.SIX:
                    return "6";
                case Face.SEVEN:
                    return "7";
                case Face.EIGHT:
                    return "8";
                case Face.NINE:
                    return "9";
                case Face.TEN:
                    return "10";
                case Face.JACK:
                    return "J";
                case Face.QUEEN:
                    return "Q";
                case Face.KING:
                    return "K";
                default:
                    throw new NotImplementedException();
            }
        }
        public Uri ImageLocation {
            get {
                return new Uri($"../Resources/{FaceChar()}{SuitChar()}.png", UriKind.Relative);
            }
        }
    }
}