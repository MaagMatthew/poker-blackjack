using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker.Controllers;
using CardGameLib.Models;
using CardGameLib.Enums;

namespace BlackjackTests
{
    [TestClass]
    public class PokerTests
    {
        PokerController poker = new PokerController(2);

        [TestMethod]
        public void FaceFromValuePass()
        {
            int kingValue = 13;
            var face = poker.FaceFromValue(kingValue);

            bool isFace = false;
            if (face == Face.KING)
            {
                isFace = true;
            }

            Assert.IsTrue(isFace);
        }
        [TestMethod]
        public void FaceFromValueFail()
        {
            int kingValue = 11;
            var face = poker.FaceFromValue(kingValue);

            bool isFace = false;
            if (face == Face.KING)
            {
                isFace = true;
            }

            Assert.IsFalse(isFace);
        }
        [TestMethod]
        public void SortHandPass()
        {
            Deck hand = new Deck(isEmpty: true);
            Card twoSpade = new Card(Suit.SPADES, Face.TWO);
            Card threeSpade = new Card(Suit.SPADES, Face.THREE);
            Card fourSpade = new Card(Suit.SPADES, Face.FOUR);
            Card fiveSpade = new Card(Suit.SPADES, Face.FIVE);

            hand.Return(fourSpade);
            hand.Return(twoSpade);
            hand.Return(fiveSpade);
            hand.Return(threeSpade);

            var sortedHand = poker.SortHand(hand);

            bool isSorted = false;

            if (sortedHand[0] == twoSpade && sortedHand[1] == threeSpade &&
                sortedHand[2] == fourSpade && sortedHand[3] == fiveSpade)
            {
                isSorted = true;
            }

            Assert.IsTrue(isSorted);
        }
        [TestMethod]
        public void SortHandFail()
        {
            Deck hand = new Deck(isEmpty: true);
            Card twoSpade = new Card(Suit.SPADES, Face.TWO);
            Card threeSpade = new Card(Suit.SPADES, Face.THREE);
            Card fourSpade = new Card(Suit.SPADES, Face.FOUR);
            Card fiveSpade = new Card(Suit.SPADES, Face.FIVE);

            hand.Return(fourSpade);
            hand.Return(twoSpade);
            hand.Return(fiveSpade);
            hand.Return(threeSpade);

            var sortedHand = poker.SortHand(hand);

            bool isSorted = false;

            if (sortedHand[0] == threeSpade && sortedHand[1] == twoSpade &&
                sortedHand[2] == fourSpade && sortedHand[3] == fiveSpade)
            {
                isSorted = true;
            }

            Assert.IsFalse(isSorted);
        }
        [TestMethod]
        public void HandScoreRoyalFlushPass()
        {
            Deck hand = new Deck(isEmpty: true);
            Card TenSpade = new Card(Suit.SPADES, Face.TEN);
            Card JackSpade = new Card(Suit.SPADES, Face.JACK);
            Card QueenSpade = new Card(Suit.SPADES, Face.QUEEN);
            Card KingSpade = new Card(Suit.SPADES, Face.KING);
            Card AceSpade = new Card(Suit.SPADES, Face.ACE);

            hand.Return(TenSpade);
            hand.Return(JackSpade);
            hand.Return(QueenSpade);
            hand.Return(KingSpade);
            hand.Return(AceSpade);

            bool isRoyalFlush = false;

            var intList = poker.HandScore(hand);

            if(intList.Contains(9))
            {
                isRoyalFlush = true;
            }

            Assert.IsTrue(isRoyalFlush);
        }
        [TestMethod]
        public void HandScoreStraightFlushPass()
        {
            Deck hand = new Deck(isEmpty: true);
            Card ThreeSpade = new Card(Suit.SPADES, Face.THREE);
            Card FourSpade = new Card(Suit.SPADES, Face.FOUR);
            Card FiveSpade = new Card(Suit.SPADES, Face.FIVE);
            Card SixSpade = new Card(Suit.SPADES, Face.SIX);
            Card SevenSpade = new Card(Suit.SPADES, Face.SEVEN);

            hand.Return(ThreeSpade);
            hand.Return(FourSpade);
            hand.Return(FiveSpade);
            hand.Return(SixSpade);
            hand.Return(SevenSpade);

            bool isStraightFlush = false;

            var intList = poker.HandScore(hand);

            if (intList.Contains(8) && intList.Contains(3))
            {
                isStraightFlush = true;
            }
            Assert.IsTrue(isStraightFlush);
        }
        [TestMethod]
        public void HandScoreFourOfAKindPass()
        {
            Deck hand = new Deck(isEmpty: true);
            Card ThreeSpade = new Card(Suit.SPADES, Face.THREE);
            Card ThreeHeart = new Card(Suit.HEARTS, Face.THREE);
            Card ThreeClubs = new Card(Suit.CLUBS, Face.THREE);
            Card ThreeDiamonds = new Card(Suit.DIAMONDS, Face.THREE);

            hand.Return(ThreeSpade);
            hand.Return(ThreeClubs);
            hand.Return(ThreeDiamonds);
            hand.Return(ThreeHeart);

            bool isFourOfAKind = false;

            var intList = poker.HandScore(hand);

            if (intList.Contains(7) && intList.Contains(3))
            {
                isFourOfAKind = true;
            }
            Assert.IsTrue(isFourOfAKind);
        }
        [TestMethod]
        public void HandScoreFullHousePass()
        {
            Deck hand = new Deck(isEmpty: true);
            Card ThreeSpade = new Card(Suit.SPADES, Face.THREE);
            Card ThreeHeart = new Card(Suit.HEARTS, Face.THREE);
            Card ThreeClubs = new Card(Suit.CLUBS, Face.THREE);
            Card QueenDiamonds = new Card(Suit.DIAMONDS, Face.QUEEN);
            Card QueenSpade = new Card(Suit.SPADES, Face.QUEEN);

            hand.Return(ThreeSpade);
            hand.Return(ThreeClubs);
            hand.Return(ThreeHeart);
            hand.Return(QueenDiamonds);
            hand.Return(QueenSpade);

            bool isFullHouse = false;

            var intList = poker.HandScore(hand);

            if (intList.Contains(6) && intList.Contains(3) && intList.Contains(12))
            {
                isFullHouse = true;
            }
            Assert.IsTrue(isFullHouse);
        }
        [TestMethod]
        public void HandScoreFlushPass()
        {
            Deck hand = new Deck(isEmpty: true);
            Card ThreeSpade = new Card(Suit.SPADES, Face.THREE);
            Card FourSpade = new Card(Suit.SPADES, Face.FOUR);
            Card SevenSpade = new Card(Suit.SPADES, Face.SEVEN);
            Card KingSpade = new Card(Suit.SPADES, Face.KING);
            Card QueenSpade = new Card(Suit.SPADES, Face.QUEEN);

            hand.Return(ThreeSpade);
            hand.Return(FourSpade);
            hand.Return(SevenSpade);
            hand.Return(KingSpade);
            hand.Return(QueenSpade);

            bool isFlush = false;

            var intList = poker.HandScore(hand);

            if (intList.Contains(5) && intList.Contains(3) && intList.Contains(4)
                && intList.Contains(7) && intList.Contains(13) && intList.Contains(12))
            {
                isFlush = true;
            }
            Assert.IsTrue(isFlush);
        }
        [TestMethod]
        public void HandScoreStraightPass()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void HandScoreThreeOfAKindPass()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void HandScoreHighCardPass()
        {
            Assert.Inconclusive();
        }
    }
}