using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGameLib.Enums;
using CardGameLib.Models;


namespace Poker.Controllers
{
    public class BlackJackController
    {
        public Deck GameDeck { get; set; }
        public List<Player> Players { get; set; }
        public Dictionary<Face, int> keyValues = new Dictionary<Face, int>();
        public House house = new House();

        public BlackJackController(int players = 1)
        {
            // Adding all the numeric values for the Card
            keyValues.Add(Face.TWO, 2);
            keyValues.Add(Face.THREE, 3);
            keyValues.Add(Face.FOUR, 4);
            keyValues.Add(Face.FIVE, 5);
            keyValues.Add(Face.SIX, 6);
            keyValues.Add(Face.SEVEN, 7);
            keyValues.Add(Face.EIGHT, 8);
            keyValues.Add(Face.NINE, 9);
            keyValues.Add(Face.TEN, 10);
            keyValues.Add(Face.JACK, 10);
            keyValues.Add(Face.QUEEN, 10);
            keyValues.Add(Face.KING, 10);
            keyValues.Add(Face.ACE, 11);
            for (int i = 0; i < players; i++)
            {
                //Gives each player a hand, which will be empty
                Players.Add(new Player());
            }

            GameDeck = new Deck();
            GameDeck.Shuffle();

            //Each player draws two cards
            foreach (var person in Players)
            {
                person.Hand.Return(GameDeck.Draw());
                person.Hand.Return(GameDeck.Draw());
            }

            house.HouseHand.Return(GameDeck.Draw());
            house.HouseHand.Return(GameDeck.Draw());
        }

        /* Takes in each of the bets and applies it to their accounts
         * 
         */
        public void InitialBet(List<int> bets)
        {
            if (Players.Count == bets.Count)
            {
                int i = 0;
                foreach (var person in Players)
                {
                    person.Bet(bets[i]);
                }
            }
            else
            {
                throw new Exception();

            }
        }
        private void ProcessHouseTurn()
        {
            int handValue = GetHandValue(house.HouseHand);
            if (handValue < 17)
            {
                Card card = GameDeck.Draw();
                house.HouseHand.Return(card);
            }
        }

        private void EndOfRound()
        {
            Payout();

            foreach (var person in Players)
            {
                if (person.Money == -50)
                {
                    Players.Remove(person);
                }
            }
            //Go into the next round
        }

        private void Payout()
        {
            foreach (var player in Players)
            {
                string result = CheckHands(player);

                switch (result)
                {
                    case "Draw":
                        player.Money += player.BetPool;
                        break;
                    case "Win":
                        player.Money += player.BetPool * 2;
                        break;
                    case "Charlie":
                        player.Money += player.BetPool * 4;
                        break;
                    case "Blackjack":
                        player.Money += player.BetPool * 3;
                        break;
                    default:
                        player.Money -= player.BetPool;
                        break;
                }
            }
        }

        private string CheckHands(Player player)
        {
            if (BlackJack(player.Hand))
            {
                return "Blackjack";
            }
            else if (BeatHouse(player.Hand))
            {
                return "Win";
            }
            else if (HouseDraw(player.Hand))
            {
                return "Draw";
            }
            else if (FiveCardCharlie(player.Hand))
            {
                return "Charlie";
            }
            return "Lost";
        }

        private bool BlackJack(Deck hand)
        {
            int points = GetHandValue(hand);
            if (points == 21)
            {
                return true;
            }
            return false;
        }

        private bool BeatHouse(Deck hand)
        {
            int playerPoints = GetHandValue(hand);
            int housePoints = GetHandValue(house.HouseHand);

            if (playerPoints > housePoints && playerPoints < 22)
            {
                return true;
            }

            return false;
        }

        private bool HouseDraw(Deck hand)
        {
            int playerPoints = GetHandValue(hand);
            int housePoints = GetHandValue(house.HouseHand);

            if (playerPoints == housePoints && playerPoints < 22)
            {
                return true;
            }
            return false;
        }

        private bool FiveCardCharlie(Deck hand)
        {
            var cards = hand.GetCards();

            if (cards.Count >= 5)
            {
                return true;
            }
            return false;
        }

        private int GetHandValue(Deck hand)
        {
            int points = 0;
            var cards = hand.GetCards();
            foreach (var card in cards)
            {
                if (keyValues.ContainsKey(card.Face))
                {
                    points += keyValues[card.Face];
                }
            }
            return points;
        }
    }
}