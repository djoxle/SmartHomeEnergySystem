using Battery;
using Battery.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    [TestFixture]
    public class BaterijaTest
    {
        [Test]
        public void TestID()
        {
            var t = new Baterija();
            t.ID = 5;

            Assert.AreEqual(t.ID, 5);
        }
        [Test]
        public void TestIme()
        {
            var t = new Baterija();
            t.Ime = "value";

            Assert.AreEqual(t.Ime, "value");
        }

        [Test]
        public void TestMaksimalnaSnaga()
        {
            var t = new Baterija();
            t.MaksimalnaSnaga = 550;

            Assert.AreEqual(t.MaksimalnaSnaga, 550);
        }

        [Test]
        public void TestKapacitet()
        {
            var t = new Baterija();
            t.Kapacitet = 15;

            Assert.AreEqual(t.Kapacitet, 15);
        }

        [Test]
        public void TestIDNotValid()
        {
            var t = new Baterija();
            t.ID = 5;

            Assert.AreNotEqual(t.ID, 15);
        }
        [Test]
        public void TestImeNotValid()
        {
            var t = new Baterija();
            t.Ime = "value";

            Assert.AreNotEqual(t.Ime, "valuee");
        }

        [Test]
        public void TestMaksimalnaSnagaNotValid()
        {
            var t = new Baterija();
            t.MaksimalnaSnaga = 550;

            Assert.AreNotEqual(t.MaksimalnaSnaga, 551);
        }

        [Test]
        public void TestKapacitetNotValid()
        {
            var t = new Baterija();
            t.Kapacitet = 15;

            Assert.AreNotEqual(t.Kapacitet, 14);
        }
    }
}
