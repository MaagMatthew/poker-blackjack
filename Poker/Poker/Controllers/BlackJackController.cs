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

            for(int i = 0; i < players; i++)
            {
                //Gives each player a hand, which will be empty
                Players.Add(new Player());
            }
            
        }
        
    }
}
