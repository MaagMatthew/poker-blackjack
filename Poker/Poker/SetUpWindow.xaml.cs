using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using System.Reflection;

namespace Poker
{
    /// <summary>
    /// Interaction logic for SetUpWindow.xaml
    /// </summary>
    public partial class SetUpWindow : Window
    {

        public int BoundNumber { get; set; }
<<<<<<< HEAD

        public string GameType { get; set; }
=======
        public Type GameType { get; set; }
>>>>>>> Alice's-Work
        public int Min { get; set; }
        public int Max { get; set; }
      
        public SetUpWindow(Type d, int min, int max)
        {
<<<<<<< HEAD
            DataContext = this;
            GameType = gt;
=======
            GameType = d;
>>>>>>> Alice's-Work
            Min = min;
            Max = max;
            Window_Loaded();
            InitializeComponent();
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
            GameWindow gw = new GameWindow(GameType, BoundNumber);
            gw.Show();
=======
            Object boi = null;
            MethodInfo NWConstructor = GameType.GetMethod($"Init", new Type[] { typeof(int) });
            Object nextWindow = NWConstructor.Invoke( boi, new Object[] { _boundNumber });
            MethodInfo NWShow = GameType.GetMethod($"Show", new Type[] { });
            NWShow.Invoke(nextWindow, null);
>>>>>>> Alice's-Work
            this.Close();
        }

        private void More_Click(object sender, RoutedEventArgs e)
        {
            if(BoundNumber >= Min && BoundNumber < Max)
            {
                BoundNumber = BoundNumber + 1;
                PlayerNum.Text = BoundNumber.ToString();
            }
        }

        private void Fewer_Click(object sender, RoutedEventArgs e)
        {
            if (BoundNumber > Min && BoundNumber <= Max)
            {
                BoundNumber = BoundNumber - 1;
                PlayerNum.Text = BoundNumber.ToString();
            }
        }

        private void Window_Loaded()
        {
            BoundNumber = Min;
            PlayerNum.Text = BoundNumber.ToString();
        }
    }
}
