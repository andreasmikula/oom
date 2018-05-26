using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class TicketID : IAttend
    {
        private int Id;
        public decimal Price { get; set; }

        public TicketID(int id, decimal price)
        {
            Id = id;
            Price = price;
        }

        public void updatePrice(int price)
        {
            if (price >= Price)
                Price = price;
            throw new ArgumentOutOfRangeException("Your price " + price.ToString() + " is smaller than current price " + Price.ToString());
        }

        public int getID()
        {
            return Id;
        }

        public bool Presence()
        {
            return false;
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}", Id.ToString(), Price.ToString(), Presence().ToString());
        }
    }
}
