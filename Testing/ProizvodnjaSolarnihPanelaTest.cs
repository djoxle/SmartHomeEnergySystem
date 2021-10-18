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
    public class ProizvodnjaSolarnihPanelaTest
    {
        [Test]
        public void TestID()
        {
            var t = new ProizvodnjaSolarnihPanela();
            t.ID = 232;

            Assert.AreEqual(t.ID, 232);
        }

        [Test]
        public void TestSnaga()
        {
            var t = new ProizvodnjaSolarnihPanela();
            t.Snaga = 121.3;

            Assert.AreEqual(t.Snaga, 121.3);
        }

        [Test]
        public void TestDatum()
        {
            var t = new ProizvodnjaSolarnihPanela();
            DateTime justDate = new DateTime(2020, 6, 14);
            t.Datum = justDate;

            Assert.AreEqual(t.Datum, justDate);
        }
    }
}
