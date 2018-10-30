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
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class PokerGameWindow : Window
    {
        
        public int NumOfPlayers { get; set; }
        public List<Player>  players { get; set; }
        public PokerGameWindow(int NumOfP)
        {
            NumOfPlayers = NumOfP;
            players = new List<Player>();
            OnNavigatedTo();

            InitializeComponent();
        }
         
        public PokerGameWindow()
        {

        }

        public void OnNavigatedTo()
        {
            for(int i = 0; i < NumOfPlayers; i++)
            {
                Player p = new Player();
                players.Add(p);
            }
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
