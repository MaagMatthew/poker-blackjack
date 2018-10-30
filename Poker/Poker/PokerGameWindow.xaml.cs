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
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class PokerGameWindow : Window
    {
<<<<<<< HEAD
        private PokerController controller;
=======
        
        public int NumOfPlayers { get; set; }
        public List<Player>  players { get; set; }
>>>>>>> Alice's-Work
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
