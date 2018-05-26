using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task4
{
    [TestFixture]

    public class Tests
    {
        [Test]
        public void Test1()
        {
            TicketID ticketid = new TicketID(4, 39M);
            Assert.IsFalse(ticketid.Presence());
        }

        [Test]
        public void Test2()
        {
            Concert concert = new Concert("Test", "Test", "Test", 70);
            Assert.IsTrue(concert.Presence());
        }

        [Test]
        public void Test3()
        {
            Concert concert = new Concert("Test", "Test", "Test", 180);
            Assert.IsTrue(concert.Price == 180);
            concert.updatePrice(190);
            Assert.IsTrue(concert.Price == 190);
        }

        [Test]
        public void Test4()
        {
            Concert concert = new Concert("Test", "Test", "Test", 180);
            var except = Assert.Throws<ArgumentOutOfRangeException>(() => concert.updatePrice(100));
            Assert.That(except.ParamName, Is.EqualTo("Your price 100 is smaller than current price 180"));
        }

        [Test]
        public void Test5()
        {
            TicketID ticketid = new TicketID(4, 39M);
            Assert.IsTrue(ticketid.getID() == 4);
            ticketid.updatePrice(38);
            Assert.IsTrue(ticketid.getID() == 38);
        }

        [Test]
        public void Test6()
        {
            TicketID ticketid = new TicketID(4, 39M);
            var except = Assert.Throws<ArgumentOutOfRangeException>(() => ticketid.updatePrice(9));
            Assert.That(except.ParamName, Is.EqualTo("Your price 9 is smaller than current price 39"));
        }

        [Test]
        public void Test7()
        {
            Concert concert = new Concert("Test", "Test", "Test", 70);
            Assert.That(concert.ToString(), Is.EqualTo("Test, Test, Test, 70, True\n"));
        }

        [Test]
        public void Test8()
        {
            TicketID ticketid = new TicketID(10, 0.1M);
            Assert.That(ticketid.ToString(), Is.EqualTo("10, 0,1, False"));
        }
    }
}
