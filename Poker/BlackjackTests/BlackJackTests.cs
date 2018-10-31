using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker.Controllers;
using CardGameLib.Models;
using CardGameLib.Enums;
using System.Collections.Generic;

namespace BlackjackTests
{
    [TestClass]
    public class BlackJackTests
    {
        //Getting HandValues
        #region Getting Hand Values

        [TestMethod]
        public void GetHandValuePass()
        {
            BlackJackController blackJack = new BlackJackController(1);
            Deck deck = new Deck();
            Deck playerHand = new Deck(true);

            Card king = new Card(Suit.CLUBS, Face.KING);
            Card Eight = new Card(Suit.CLUBS, Face.EIGHT);
            playerHand.Return(king);
            playerHand.Return(Eight);

            bool IsValue = false;

            if (blackJack.GetHandValue(playerHand) == 18)
            {
                IsValue = true;
            }

            Assert.IsTrue(IsValue);
        }
        [TestMethod]
        public void GetHandValueFail()
        {
            BlackJackController blackJack = new BlackJackController(1);
            Deck deck = new Deck();
            Deck playerHand = new Deck(true);

            Card king = new Card(Suit.CLUBS, Face.KING);
            Card Ace = new Card(Suit.CLUBS, Face.ACE);
            playerHand.Return(king);
            playerHand.Return(Ace);

            bool IsValue = false;

            if (blackJack.GetHandValue(playerHand) == 18)
            {
                IsValue = true;
            }

            Assert.IsFalse(IsValue);
        }
        #endregion

        //Win Conditions

        #region Win Conditions

        [TestMethod]
        public void FiveCardCharliePass()
        {
            BlackJackController blackJack = new BlackJackController(1);
            Deck deck = new Deck();
            Deck playerHand = new Deck(true);

            Card TwoSpade = new Card(Suit.SPADES, Face.TWO);
            Card TwoClub = new Card(Suit.CLUBS, Face.TWO);
            Card TwoHeart = new Card(Suit.HEARTS, Face.TWO);
            Card TwoDiamond = new Card(Suit.DIAMONDS, Face.TWO);
            Card ThreeSpade = new Card(Suit.SPADES, Face.THREE);
            playerHand.Return(TwoSpade);
            playerHand.Return(TwoClub);
            playerHand.Return(TwoHeart);
            playerHand.Return(TwoDiamond);
            playerHand.Return(ThreeSpade);


            bool isCharlie = blackJack.FiveCardCharlie(playerHand);

            Assert.IsTrue(isCharlie);
        }
        [TestMethod]
        public void FiveCardCharlieFail()
        {
            BlackJackController blackJack = new BlackJackController(1);
            Deck deck = new Deck();
            Deck playerHand = new Deck(true);

            Card AceSpade = new Card(Suit.SPADES, Face.ACE);
            Card AceClub = new Card(Suit.CLUBS, Face.ACE);
            Card AceHeart = new Card(Suit.HEARTS, Face.ACE);
            playerHand.Return(AceClub);
            playerHand.Return(AceSpade);
            playerHand.Return(AceHeart);


            bool isCharlie = blackJack.FiveCardCharlie(playerHand);

            Assert.IsFalse(isCharlie);
        }
        [TestMethod]
        public void BeatHousePass()
        {
            BlackJackController blackJack = new BlackJackController(1);
            Deck deck = new Deck();
            Deck playerHand = new Deck(true);
            Deck houseHand = new Deck(true);

            Card AceSpade = new Card(Suit.SPADES, Face.ACE);
            Card KingSpade = new Card(Suit.SPADES, Face.KING);
            playerHand.Return(AceSpade);
            playerHand.Return(KingSpade);

            Card SevenClub = new Card(Suit.CLUBS, Face.SEVEN);
            Card TwoHeart = new Card(Suit.HEARTS, Face.TWO);
            houseHand.Return(SevenClub);
            houseHand.Return(TwoHeart);

            bool beatHouse = false;

            if (blackJack.GetHandValue(playerHand) > blackJack.GetHandValue(houseHand)
                && blackJack.GetHandValue(playerHand) <= 21)
            {
                beatHouse = true;
            }

            Assert.IsTrue(beatHouse);
        }
        [TestMethod]
        public void BeatHouseFail()
        {
            BlackJackController blackJack = new BlackJackController(1);
            Deck deck = new Deck();
            Deck playerHand = new Deck(true);
            Deck houseHand = new Deck(true);

            Card AceSpade = new Card(Suit.SPADES, Face.ACE);
            Card KingSpade = new Card(Suit.SPADES, Face.KING);
            houseHand.Return(AceSpade);
            houseHand.Return(KingSpade);

            Card SevenClub = new Card(Suit.CLUBS, Face.SEVEN);
            Card TwoHeart = new Card(Suit.HEARTS, Face.TWO);
            playerHand.Return(SevenClub);
            playerHand.Return(TwoHeart);

            bool beatHouse = false;

            if (blackJack.GetHandValue(playerHand) > blackJack.GetHandValue(houseHand)
                && blackJack.GetHandValue(playerHand) < 21)
            {
                beatHouse = true;
            }

            Assert.IsFalse(beatHouse);
        }
        [TestMethod]
        public void BlackJackPass()
        {
            BlackJackController blackJack = new BlackJackController(1);
            Deck deck = new Deck();
            Deck playerHand = new Deck(true);

            Card AceSpade = new Card(Suit.SPADES, Face.ACE);
            Card KingSpade = new Card(Suit.SPADES, Face.KING);
            playerHand.Return(AceSpade);
            playerHand.Return(KingSpade);

            bool isBlackjack = blackJack.BlackJack(playerHand);

            Assert.IsTrue(isBlackjack);
        }
        [TestMethod]
        public void BlackJackFail()
        {
            BlackJackController blackJack = new BlackJackController(1);
            Deck deck = new Deck();
            Deck playerHand = new Deck(true);

            Card AceSpade = new Card(Suit.SPADES, Face.ACE);
            Card KingSpade = new Card(Suit.SPADES, Face.KING);
            Card TenHeart = new Card(Suit.HEARTS, Face.TEN);
            playerHand.Return(AceSpade);
            playerHand.Return(KingSpade);
            playerHand.Return(TenHeart);

            bool isBlackjack = blackJack.BlackJack(playerHand);

            Assert.IsFalse(isBlackjack);
        }

        #endregion

        #region Draw Conditions

        [TestMethod]
        public void HouseDrawPass()
        {
            BlackJackController blackJack = new BlackJackController(1);
            Deck deck = new Deck();
            Deck playerHand = new Deck(true);
            Deck houseHand = new Deck(true);

            Card TenSpade = new Card(Suit.SPADES, Face.TEN);
            Card SevenHeart = new Card(Suit.HEARTS, Face.SEVEN);
            playerHand.Return(TenSpade);
            playerHand.Return(SevenHeart);

            Card SevenClub = new Card(Suit.CLUBS, Face.SEVEN);
            Card QueenSpade = new Card(Suit.SPADES, Face.QUEEN);
            houseHand.Return(SevenClub);
            houseHand.Return(QueenSpade);

            bool drawHouse = false;

            if (blackJack.GetHandValue(playerHand) == blackJack.GetHandValue(houseHand)
                && blackJack.GetHandValue(playerHand) < 21)
            {
                drawHouse = true;
            }

            Assert.IsTrue(drawHouse);
        }

        [TestMethod]
        public void HouseDrawFail()
        {
            BlackJackController blackJack = new BlackJackController(1);
            Deck deck = new Deck();
            Deck playerHand = new Deck(true);
            Deck houseHand = new Deck(true);

            Card TwoSpade = new Card(Suit.SPADES, Face.TWO);
            Card SevenHeart = new Card(Suit.HEARTS, Face.SEVEN);
            playerHand.Return(TwoSpade);
            playerHand.Return(SevenHeart);

            Card SevenClub = new Card(Suit.CLUBS, Face.SEVEN);
            Card QueenSpade = new Card(Suit.SPADES, Face.QUEEN);
            houseHand.Return(SevenClub);
            houseHand.Return(QueenSpade);

            bool drawHouse = false;

            if (blackJack.GetHandValue(playerHand) == blackJack.GetHandValue(houseHand)
                && blackJack.GetHandValue(playerHand) < 21)
            {
                drawHouse = true;
            }

            Assert.IsFalse(drawHouse);
        }
        #endregion
    }
}
