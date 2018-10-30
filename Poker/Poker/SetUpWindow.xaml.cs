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
using System.Reflection;

namespace Poker
{
    /// <summary>
    /// Interaction logic for SetUpWindow.xaml
    /// </summary>
    public partial class SetUpWindow : Window
    {
        private int _boundNumber;
        public int BoundNumber { get; set; }
        public Type GameType { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
      
        public SetUpWindow(Type d, int min, int max)
        {
            GameType = d;
            Min = min;
            Max = max;
            Window_Loaded();
            InitializeComponent();
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            Object boi = null;
            MethodInfo NWConstructor = GameType.GetMethod($"Init", new Type[] { typeof(int) });
            Object nextWindow = NWConstructor.Invoke( boi, new Object[] { _boundNumber });
            MethodInfo NWShow = GameType.GetMethod($"Show", new Type[] { });
            NWShow.Invoke(nextWindow, null);
            this.Close();
        }

        private void More_Click(object sender, RoutedEventArgs e)
        {
            BoundNumber += 1;
        }

        private void Fewer_Click(object sender, RoutedEventArgs e)
        {
            BoundNumber -= 1;

        }

        private void Window_Loaded()
        {
            BoundNumber = 1;
        }
    }
}
