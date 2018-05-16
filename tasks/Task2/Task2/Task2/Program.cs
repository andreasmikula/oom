using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Concert concert1 = new Concert("Godsmack", "11.09.2018", "Arena Wien", 30);
            Concert concert2 = new Concert("Lamb of God", "13.11.2018", "Stadthalle Wien", 59);
            Concert concert3 = new Concert("Soulfly", "10.07.2018", "Szene Wien", 29);
            Concert concert4 = new Concert("Judas Priest", "28.07.2018", "Stadthalle Wien", 67);
            Console.WriteLine(concert1.ToString());
            Console.WriteLine(concert2.ToString());
            Console.WriteLine(concert3.ToString());

            Console.WriteLine("concert4 before change: {0}", concert2.ToString());
            concert2.updatePrice(69);
            Console.WriteLine("concert4 after change: {0}", concert2.ToString());

        }
    }
}
