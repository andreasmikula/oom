using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            IAttend[] attends = new IAttend[]
                {
            new Concert("Godsmack", "17.11.2018", "Arena Wien", 34),
            new TicketID(10, 37.90M),
                };

            foreach (IAttend x in attends)
            {
                Console.WriteLine(x.ToString());
            }
        }
    }
}
