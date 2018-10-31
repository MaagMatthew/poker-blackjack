using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameLib.Models
{
    public class Player
    {
        public int Money { get; set; }
        public string Username { get; set; }
        public Deck Hand { get; set; }
        public Deck SecondaryHand { get; set; }
        public bool Dealer { get; set; }
        public int BetPool { get; set; }

        public Player()
        {
            Money = 0;
            Username = "CPU";
            Hand = new Deck(true);
            SecondaryHand = new Deck(true);
        }
        public Player(int money)
        {
            Money = money;
            Username = "CPU";
            SecondaryHand = new Deck(true);
            Hand = new Deck(true);
        }
        public Player(string username)
        {
            Money = 0;
            Hand = new Deck(true);
            SecondaryHand = new Deck(true);
            Username = username;
        }
        public Player(Deck deck)
        {
            Money = 0;
            Username = "CPU";
            SecondaryHand = new Deck(true);
            Hand = deck;
        }
        public Player(int money, string username)
        {
            Hand = new Deck(true);
            Money = money;
            Username = username;
        }
        public Player(string username, Deck deck)
        {
            Money = 0;
            Username = username;
            SecondaryHand = new Deck(true);
            Hand = deck;
        }
        public Player(int money, Deck deck)
        {
            Username = "CPU";
            Money = money;
            Hand = deck;
        }
        public Player(int money, string username, Deck deck)
        {
            Money = money;
            Username = username;
            SecondaryHand = new Deck(true);
            Hand = deck;
        }

        public void Bet(int money)
        {
            if(money <= Money)
            {
                Money -= money;
                BetPool += Money;
            }
        }
        
        public void Payout(int money)
        {
            if(money >= 0)
            {
                Money += money;
                BetPool = 0;
            }
        }
    }
}
