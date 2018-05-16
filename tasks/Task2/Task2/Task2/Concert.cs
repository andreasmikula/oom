using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Concert
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

        public void updatePrice (int price)
        {
            if (price >= Price)
                Price = price;
            else
                throw new ArgumentOutOfRangeException("Your price " + price.ToString() + "is smaller than current price " + Price.ToString());
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}, {3}\n", Band, Date, Location, Price.ToString());
        }
    }
}
