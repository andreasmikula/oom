using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    class Concert : IAttend
    {
        private string Band;
        public string Date { get; }
        public string Location { get; set; }
        public int Price { get; set; }

        public Concert(string band, string date, string location, int price)
        {
            Band = band;
            Date = date;
            Location = location;
            Price = price;
        }

        public void updatePrice(int price)
        {
            if (price >= Price)
                Price = price;
            else
                throw new ArgumentOutOfRangeException("Your price " + price.ToString() + " is smaller than current price " + Price.ToString());
        }

        override public string ToString()
        {
            return String.Format("{0}, {1}, {2}, {3}, {4}\n", Band, Date, Location, Price.ToString(), Presence());
        }
        public bool Presence()
        {
            return true;
        }
    }
}
