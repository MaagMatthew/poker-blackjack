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

namespace Poker
{
    /// <summary>
    /// Interaction logic for BlackJackGameWindow.xaml
    /// </summary>
    public partial class BlackJackGameWindow : Window
    {
        public List<Player> players { get; set; }
        public BlackJackGameWindow(int NumOfPlayers)
        {
            players = new List<Player>();
            for(int i = 0; i < NumOfPlayers; i++)
            {
                Player p = new Player();
                players.Append(p);
            }
            InitializeComponent();
        }

        private void Hit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Split_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Pass_Click(object sender, RoutedEventArgs e)
        {

        }

        public static BlackJackGameWindow Init(int NumOfPlayers)
        {
            return new BlackJackGameWindow(NumOfPlayers);
        }

    }
}
