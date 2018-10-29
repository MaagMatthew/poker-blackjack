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

namespace Poker
{
    /// <summary>
    /// Interaction logic for SetUpWindow.xaml
    /// </summary>
    public partial class SetUpWindow : Window
    {
        private int _boundNumber;
        public int BoundNumber { get; set; }
        public string GameType { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public SetUpWindow(string gt, int min, int max)
        {
            GameType = gt;
            Min = min;
            Max = max;
            InitializeComponent();
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            if (GameType.Equals("Poker"))
            {
                PokerGameWindow pgw = new PokerGameWindow(_boundNumber);
                pgw.Show();
                this.Close();
            }
            else if(GameType.Equals("BlackJack"))
            {
                BlackJackGameWindow gw = new BlackJackGameWindow(_boundNumber);
                gw.Show();
                this.Close();
            }
        }

        private void More_Click(object sender, RoutedEventArgs e)
        {
            BoundNumber += 1;
        }

        private void Fewer_Click(object sender, RoutedEventArgs e)
        {
            BoundNumber -= 1;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BoundNumber = 1;
        }
    }
}
