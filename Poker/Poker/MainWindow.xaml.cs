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

        private void Poker_Click(object sender, RoutedEventArgs e)
        {
            SetUpWindow poker = new SetUpWindow();
            poker.Show();
            this.Close();
        }

        private void BlackJack_Click(object sender, RoutedEventArgs e)
        {
            SetUpWindow blackJack = new SetUpWindow();
            blackJack.Show();
            this.Close();
        }
    }
}
