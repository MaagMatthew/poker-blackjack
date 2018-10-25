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

        public BlackJackController(int players = 1)
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

            foreach (var player in Players)
            {
                string result = CheckHands(player);

                switch (result)
                {
                    case "Draw":
                        player.Money += 20; //Replace 20 with their bet value
                        break;
                    case "Win":
                        player.Money += 40; //Replace 40 with their bet X 2
                        break;
                    case "Charlie":
                        player.Money += 80; //Replace 80 with their bet X 4
                        break;
                    case "Blackjack":
                        player.Money += 60; //Rel=place 60 with thier bet X 3
                        break;
                    default:
                        player.Money -= 20; //Replace 20 with their bet value
                        break;
                }
            }
        }

        private string CheckHands(Player player)
        {
            //Check the players hand and see if their card values match the house, beat the house, they have blackjack, or have a 5-card charlie



            return "Lost";
        }
    }
}