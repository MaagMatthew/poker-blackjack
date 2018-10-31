using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Controllers
{
    public class WindowOpener
    {
        public delegate void OpenWindow(int playerNum);

        public void OpenBlackJack(int playerNum)
        {
            BlackJackGameWindow gameWindow = new BlackJackGameWindow(playerNum);
            gameWindow.Show();
        }

        public void OpenPoker(int playerNum)
        {
            PokerGameWindow gameWindow = new PokerGameWindow(playerNum);
            gameWindow.Show();
        }
    }
}
