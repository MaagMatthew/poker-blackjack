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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Poker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Navigates to the Setup window with a string value of "Poker" to allow that window and the game to know
        ///     that it should load the poker library
        /// </summary>
        /// <param name="sender"> the button itself</param>
        /// <param name="e">the mouse</param>
        private void Poker_Click(object sender, RoutedEventArgs e)
        {
            SetUpWindow poker = new SetUpWindow("Poker",2,4);
            poker.Show();
            this.Close();
        }


        /// <summary>
        ///     Navigates to the Setup window with a string value of "Black Jack" to allow that window and the game to know
        ///     that it should load the Black Jack library
        /// </summary>
        /// <param name="sender"> the button itself</param>
        /// <param name="e">the mouse</param>
        private void BlackJack_Click(object sender, RoutedEventArgs e)
        {
            SetUpWindow blackJack = new SetUpWindow("BlackJack",1,5);
            blackJack.Show();
            this.Close();
        }
    }
}
