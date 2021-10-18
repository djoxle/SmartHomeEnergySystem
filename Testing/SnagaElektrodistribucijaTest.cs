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
    public class SnagaElektrodistribucijaTest
    {
        [TestFixture]
        public class ProizvodnjaSolarnihPanelaTest
        {
            [Test]
            public void TestID()
            {
                var t = new SnagaElektrodistribucija();
                t.ID = 2;

                Assert.AreEqual(t.ID, 2);
            }

            [Test]
            public void TestSnaga()
            {
                var t = new SnagaElektrodistribucija();
                t.Snaga = 231.3;

                Assert.AreEqual(t.Snaga, 231.3);
            }

            [Test]
            public void TestCena()
            {
                var t = new SnagaElektrodistribucija();
                t.Cena= 2231.3;

                Assert.AreEqual(t.Cena, 2231.3);
            }

            [Test]
            public void TestDatum()
            {
                var t = new SnagaElektrodistribucija();
                DateTime justDate = new DateTime(2020, 6, 14);
                t.Datum = justDate;

                Assert.AreEqual(t.Datum, justDate);
            }
        }
    }
}
