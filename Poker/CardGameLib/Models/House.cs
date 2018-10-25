using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameLib.Models
{
    public class House
    {
        public Deck HouseHand { get; set; }

        public House()
        {
            HouseHand = new Deck(true);
        }
    }
}
