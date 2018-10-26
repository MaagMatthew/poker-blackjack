using CardGameLib.Enums;
using CardGameLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Controllers
{
    class PokerController
    {
        private Dictionary<Face, int> FaceValues = new Dictionary<Face, int>();
        public PokerController() {
            FaceValues.Add(Face.TWO, 0);
            FaceValues.Add(Face.THREE, 1);
            FaceValues.Add(Face.FOUR, 2);
            FaceValues.Add(Face.FIVE, 3);
            FaceValues.Add(Face.SIX, 4);
            FaceValues.Add(Face.SEVEN, 5);
            FaceValues.Add(Face.EIGHT, 6);
            FaceValues.Add(Face.NINE, 7);
            FaceValues.Add(Face.TEN, 8);
            FaceValues.Add(Face.JACK, 9);
            FaceValues.Add(Face.QUEEN, 10);
            FaceValues.Add(Face.KING, 11);
            FaceValues.Add(Face.ACE, 12);
        }
        public double HandScore(Deck hand) {

            throw new NotImplementedException();
        }
        private Deck SortHand(Deck hand) {
            Deck handCopy = new Deck(true);
            for (int i = 0; i < hand.Size; i++) {
                handCopy.Return(hand[i]);
            }
            Deck result = new Deck(true);

            while (handCopy.Size != 0) {
                int lowestIndex = 0;
                for (int i = 0; i < handCopy.Size; i++) {
                    if (FaceValues[handCopy[lowestIndex].Face] > FaceValues[handCopy[i].Face]) {
                        lowestIndex = i;
                    }
                }
                result.Return(handCopy.Remove(lowestIndex));
            }
            return result;
        }
    }
}
