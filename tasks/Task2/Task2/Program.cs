using System;
using System.Linq;

namespace Task2
{
    class MainClass
    {
        public static void Main (string[] args)
        {
            var concert = new[]
            {
                new Concerts("Soulfy", "10.07.2018", "Szene Wien", 29.00m, Currency.EUR),
                new Concerts("Judas Priest", "28.07.2018", "Stadthalle Wien", 66.99m, Currency.EUR),
                new Concerts("Godsmack", "20.11.2018", "Arena Wien", 35.99m, Currency.EUR),
                new Concerts("Lamb of God", "23.11.2018", "Stadthalle Wien", 74.99m, Currency.EUR),
            };
        }
    }
}