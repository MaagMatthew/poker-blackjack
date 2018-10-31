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

        public Type GameType { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
      
        public SetUpWindow(Type d, int min, int max)
        {
            DataContext = this;
            GameType = d;
            Min = min;
            Max = max;
            InitializeComponent();
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            Object boi = null;
            MethodInfo NWConstructor = GameType.GetMethod($"Init", new Type[] { typeof(int) });
            Object nextWindow = NWConstructor.Invoke( boi, new Object[] { BoundNumber });
            MethodInfo NWShow = GameType.GetMethod($"Show", new Type[] { });
            NWShow.Invoke(nextWindow, null);
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BoundNumber = Min;
            PlayerNum.Text = BoundNumber.ToString();
        }
    }
}
