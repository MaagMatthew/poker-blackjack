using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CardGameLib.Models;
using CardGameLib.Enums;
using Poker.Controllers;

namespace Poker
{
    //Picking a Dealer - Cards are given out to everyone and whoever has the highest ranking value is the dealer then the rotation starts left
    //Putting out the blinds - Player to the left of the dealer will put out a small or big blind (bet) && Big blinds will be twice the value of small blinds
    //Each player gets a card during rotation and stops when they all have 2 cards (hole cards) and one has placed a big blind
    //Pre-Flop Round - Starts after all players received hole cards and with the player to the left of the big blind
    //Player (Fold/Call/Raise) and rotates the left
    //Ends when all players have had their turns and those that didn't folded all have same amount of money
    //Flop round -> Post-Flop round
    //Turn/River round
    //Showdown round
    //4 Rounds - Each ends when all but one have folded
    //Player with best hand/most chips wins

    public partial class PokerGameWindow : Window
    {
        private PokerController controller;
        public int NumOfPlayers { get; set; }
        public List<Player> players { get; set; }
        public PokerGameWindow(int NumOfP)
        {
            OnNavigatedTo();

            controller = new PokerController(NumOfP);

            InitializeComponent();
        }
         
        public PokerGameWindow()
        {

        }

        public void OnNavigatedTo()
        {
            
        }

        private void Fold_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Draw_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Call_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RaiseButton_Click(object sender, RoutedEventArgs e)
        {

        }

        public static PokerGameWindow Init(int NumOfPlayers)
        {
            return new PokerGameWindow(NumOfPlayers);
        }
    }
}
