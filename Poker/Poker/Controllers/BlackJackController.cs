using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGameLib.Models;


namespace Poker.Controllers
{
    class BlackJackController
    {
        public Deck deck { get; set; }
        public List<Player> Players { get; set; }

        public BlackJackController(int players = 2)
        {

            for (int i = 0; i < players; i++)
            {
                //Gives each player a hand, which will be empty
                Players.Add(new Player());
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
        }
        private void Payout()
        {
            //Pay out what the players have won/lost this round
            //Draw: return cost of hand
            //Win: return 2x cost of hand
            //Blackjack: Return 3x cost of hand
            //5 - card Charlie: Return 4x cost of hand
        }
    }
}
