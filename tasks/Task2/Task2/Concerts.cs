using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Net;

namespace Task2
{
    public class Concerts
    {
        private decimal m_price;

        /// <summary>
        /// Creates a new bands object.
        /// </summary>
        /// <param name="name">Name must not be empty.</param>
        /// <param name="date">Date must have guilty format.</param>
        /// <param name="location">Location must not be empty.</param>
        /// <param name="price">Price must not be negative.</param>
        public Concerts(string name, string date, string location, decimal price, Currency currency)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name must not be empty!", nameof(name));
            if (string.IsNullOrWhiteSpace(location)) throw new ArgumentException("Location must not be empty!", nameof(location));

            Name = name;
            Date = date;
            Location = location;
            UpdatePrice(price, currency);
        }


        /// <summary>
        /// Gets the bands name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the date of the concert.
        /// </summary>
        public string Date { get; }

        /// <summary>
        /// Gets the location of the concert.
        /// </summary>
        public string Location { get; }

        /// <summary>
        /// Gets the currency of the concert ticket.
        /// </summary>
        public Currency currency { get; private set; }

        /// <summary>
        /// Gets the price in the given currency.
        /// </summary>
        public decimal GetPrice(Currency currency)
        {
            // if the price is requested in it's own currency, then simply return the stored price
            if (currency == Currency) return m_price;

            var from = Currency.ToString();
            var to = currency.ToString();

            // use web service to query current exchange rate
            // request : https://api.fixer.io/latest?base=EUR&symbols=USD
            // response: {"base":"EUR","date":"2018-01-24","rates":{"USD":1.2352}}
            var url = $"https://api.fixer.io/latest?base={from}&symbols={to}";
            // download the response as string
            var data = new WebClient().DownloadString(url);
            // parse JSON
            var json = JObject.Parse(data);
            // convert the exchange rate part to a decimal 
            var rate = decimal.Parse((string)json["rates"][to], CultureInfo.InvariantCulture);

            return m_price * rate;
        }

        /// <summary>
        /// Updates the ticket's price.
        /// </summary>
        /// <param name="newPrice">Price must not be negative.</param>
        /// <param name="newCurrency">Currency.</param>
        public void UpdatePrice(decimal newPrice, Currency currency)
        {
            if (newPrice < 0) throw new ArgumentException("Price must not be negative.", nameof(newPrice));
            m_price = newPrice;
            Currency = currency;
        }
    }
}