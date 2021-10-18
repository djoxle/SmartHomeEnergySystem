using NUnit.Framework;
using RES_projekat_5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    [TestFixture]
    public class PotrosnjaPotrosacaTest
    {
        [Test]
        public void TestID()
        {
            var t = new PotrosnjaPotrosaca();
            t.ID = 21;

            Assert.AreEqual(t.ID, 21);
        }

        [Test]
        public void TestSnaga()
        {
            var t = new PotrosnjaPotrosaca();
            t.Snaga = 156.3;

            Assert.AreEqual(t.Snaga, 156.3);
        }

        [Test]
        public void TestDatum()
        {
            var t = new PotrosnjaPotrosaca();
            DateTime justDate = new DateTime(2020, 6, 14);
            t.Datum = justDate;

            Assert.AreEqual(t.Datum, justDate);
        }


    }
}
