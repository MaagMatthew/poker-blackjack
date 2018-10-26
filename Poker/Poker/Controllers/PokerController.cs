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

        public Deck GameDeck { get; set; }
        public int SmallBlind { get; set; }
        public int LargeBlind { get; set; }
        public int CurrentBet { get; set; }
        public List<Player> Players { get; set; }
        public List<bool> ActivePlayers { get; set; }
        public Dictionary<Face, int> keyValues = new Dictionary<Face, int>();
        public House house = new House();

        public PokerController()
        {
            NewGame();
        }

        public void NewGame()
        {
            for(int i = 0; i < ActivePlayers.Count; i++)
            {
                if(Players[i].Money > -500)
                {
                    ActivePlayers[i] = true;
                }
            }
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
    }
}
