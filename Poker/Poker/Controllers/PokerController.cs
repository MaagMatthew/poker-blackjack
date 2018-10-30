using CardGameLib.Enums;
using CardGameLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Controllers
{
    public class PokerController
    {

        public Deck GameDeck { get; set; } = new Deck();
        public Deck CommunityCards { get; set; } = new Deck(true);
        public int SmallBlind { get; set; }
        public int LargeBlind { get; set; }
        public int CurrentBet { get; set; }
        public List<Player> Players { get; set; } = new List<Player>();
        public int SmallBlindLocation { get; set; } = 0;
        public int BigBlindLocation { get; set; }
        public int CurrentPlayer { get; set; }
        public List<bool> ActivePlayers { get; set; } = new List<bool>();
        public Dictionary<Face, int> keyValues = new Dictionary<Face, int>();
        public House house = new House();

        public PokerController(int numOfPlayers)
        {
            FaceValues.Add(Face.TWO, 2);
            FaceValues.Add(Face.THREE, 3);
            FaceValues.Add(Face.FOUR, 4);
            FaceValues.Add(Face.FIVE, 5);
            FaceValues.Add(Face.SIX, 6);
            FaceValues.Add(Face.SEVEN, 7);
            FaceValues.Add(Face.EIGHT, 8);
            FaceValues.Add(Face.NINE, 9);
            FaceValues.Add(Face.TEN, 10);
            FaceValues.Add(Face.JACK, 11);
            FaceValues.Add(Face.QUEEN, 12);
            FaceValues.Add(Face.KING, 13);
            FaceValues.Add(Face.ACE, 14);

            for (int i = 0; i < numOfPlayers; i++) {
                Players.Add(new Player(100));
                ActivePlayers.Add(true);
            }

            NewGame();
        }

        public void NewGame()
        {
            while (CommunityCards.Size != 0) {
                GameDeck.Return(CommunityCards.Draw());
            }
            foreach (Player player in Players) {
                while (player.Hand.Size != 0) {
                    GameDeck.Return(player.Hand.Draw());
                }
            }

            for (int i = 0; i < ActivePlayers.Count; i++)
            {
                if(Players[i].Money > -500)
                {
                    ActivePlayers[i] = true;
                }
            }

            GameDeck.Shuffle();
            for (int i = 0; i < ActivePlayers.Count; i++) {
                if (ActivePlayers[i]) {
                    Players[i].Hand.Return(GameDeck.Draw());
                    Players[i].Hand.Return(GameDeck.Draw());
                }
            }

            IncrementBlindLocations();
        }

        public void IncrementBlindLocations() {
            do {
                SmallBlindLocation = (SmallBlindLocation + 1) % Players.Count;
            } while (!ActivePlayers[SmallBlindLocation]);

            BigBlindLocation = (SmallBlindLocation + 1) % Players.Count;
            while (!ActivePlayers[BigBlindLocation]) {
                BigBlindLocation = (BigBlindLocation + 1) % Players.Count;
            }

            CurrentPlayer = (BigBlindLocation + 1) % Players.Count;
            while (!ActivePlayers[CurrentPlayer]) {
                CurrentPlayer = (CurrentPlayer + 1) % Players.Count;
            }
        }

        public void IncrementCurrentPlayer() {
            do {
                CurrentPlayer = (CurrentPlayer + 1) % Players.Count;
            } while (!ActivePlayers[CurrentPlayer]);
        }

        public void Raise(int money, Player p)
        {
            if(money >= CurrentBet + LargeBlind)
            {
                CurrentBet = money;
                p.Bet(CurrentBet - p.BetPool);
            }
        }

        public void Call(Player p)
        {
            p.Bet(CurrentBet - p.BetPool);
        }

        public void Fold(Player p)
        {
            p.Payout(0);

            ActivePlayers[Players.IndexOf(p)] = false;
        }

        private Dictionary<Face, int> FaceValues = new Dictionary<Face, int>();
        private Face FaceFromValue(int value) {
            foreach (KeyValuePair<Face, int> pair in FaceValues) {
                if (pair.Value == value) {
                    return pair.Key;
                }
            }
            throw new IndexOutOfRangeException($"There is no face with a value of {value}");
        }

        public List<int> HandScore(Deck hand) {
            Deck sortedHand = SortHand(hand);

            //Royal Flush
            for (int i = 0; i < hand.Size; i++) {
                Card card = hand[i];
                if (card.Face == Face.TEN) {
                    if (hand.Contains(new Card(card.Suit, Face.JACK)) &&
                        hand.Contains(new Card(card.Suit, Face.QUEEN)) &&
                        hand.Contains(new Card(card.Suit, Face.KING)) &&
                        hand.Contains(new Card(card.Suit, Face.ACE))) {
                        return new List<int> { 9 };
                    }
                }
            }

            //Straight Flush
            for (int i = sortedHand.Size - 1; i >= 0; i--) {
                Card card = sortedHand[i];
                if (FaceValues[card.Face] < 10) {
                    if (hand.Contains(new Card(card.Suit, FaceFromValue(FaceValues[card.Face] + 1))) &&
                        hand.Contains(new Card(card.Suit, FaceFromValue(FaceValues[card.Face] + 2))) &&
                        hand.Contains(new Card(card.Suit, FaceFromValue(FaceValues[card.Face] + 3))) &&
                        hand.Contains(new Card(card.Suit, FaceFromValue(FaceValues[card.Face] + 4)))) {
                        return new List<int> { 8, FaceValues[card.Face] };
                    }
                }
            }

            //Four of a Kind
            for (int i = 14; i >= 2; i--) {
                if (hand.FaceCount(FaceFromValue(i)) == 4) {
                    return new List<int> { 7, i };
                }
            }

            //Full House
            for (int i = 14; i >= 2; i--) {
                if (hand.FaceCount(FaceFromValue(i)) == 3) {
                    for (int j = 14; j >= 2; j--) {
                        if (i != j && hand.FaceCount(FaceFromValue(j)) >= 2) {
                            return new List<int> { 6, i };
                        }
                    }
                }
            }

            //Flush
            foreach (Suit suit in Enum.GetValues(typeof(Suit))) {
                if (hand.SuitCount(suit) >= 5) {
                    Deck fiveCardHand = new Deck(true);
                    for (int i = sortedHand.Size - 1; i >= 0 && fiveCardHand.Size < 5; i--) {
                        if (sortedHand[i].Suit == suit) {
                            fiveCardHand.Return(sortedHand[i]);
                        }
                    }
                    return new List<int> { 5 };
                }
            }

            //Straight
            for (int i = sortedHand.Size - 1; i >= 0; i--) {
                Card card = sortedHand[i];
                if (FaceValues[card.Face] < 9) {
                    if (hand.FaceCount(FaceFromValue(FaceValues[card.Face] + 1)) > 0 &&
                        hand.FaceCount(FaceFromValue(FaceValues[card.Face] + 2)) > 0 &&
                        hand.FaceCount(FaceFromValue(FaceValues[card.Face] + 3)) > 0 &&
                        hand.FaceCount(FaceFromValue(FaceValues[card.Face] + 4)) > 0) {
                        return new List<int> { 4, FaceValues[card.Face] };
                    }
                }
            }

            //Three of a Kind
            for (int i = 14; i >= 2; i--) {
                if (hand.FaceCount(FaceFromValue(i)) == 3) {
                    return new List<int> { 3, i };
                }
            }

            //Two Pairs & One Pair
            for (int i = 14; i >= 2; i--) {
                if (hand.FaceCount(FaceFromValue(i)) == 2) {
                    for (int j = 14; j >= 2; j--) {
                        if (i != j && hand.FaceCount(FaceFromValue(j)) == 2) {
                            return new List<int> { 2, Math.Max(i, j), Math.Min(i, j) };
                        }
                    }
                    return new List<int> { 1, i };
                }
            }

            //Highcard
            return new List<int> { 0,
                FaceValues[sortedHand[sortedHand.Size - 1].Face],
                FaceValues[sortedHand[sortedHand.Size - 2].Face],
                FaceValues[sortedHand[sortedHand.Size - 3].Face],
                FaceValues[sortedHand[sortedHand.Size - 4].Face],
                FaceValues[sortedHand[sortedHand.Size - 5].Face]
            };
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

        public List<Deck> WinningHands(params Deck[] hands) {
            List<int> highscore = new List<int> { -1 };
            foreach (Deck hand in hands) {
                List<int> score = HandScore(hand);
                for (int i = 0; i < score.Count; i++) {
                    if (score[i] > highscore[i]) {
                        highscore = score;
                    }
                    if (score[i] != highscore[i]) {
                        break;
                    }
                }
            }

            List<Deck> winners = new List<Deck>();
            foreach (Deck hand in hands) {
                if (IntListsEqual(HandScore(hand), highscore)) {
                    winners.Add(hand);
                }
            }
            return winners;
        }

        private bool IntListsEqual(List<int> list1, List<int> list2) {
            if (list1.Count != list2.Count) {
                return false;
            }
            for (int i = 0; i < list1.Count; i++) {
                if (list1[i] != list2[i]) {
                    return false;
                }
            }
            return true;
        }
    }
}
