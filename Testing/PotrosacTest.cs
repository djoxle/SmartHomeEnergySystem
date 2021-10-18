using Consumers;
using Consumers.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    [TestFixture]
    public class PotrosacTest
    {
        [Test]
        public void TestID()
        {
            var t = new Potrosac();
            t.ID = 10;

            Assert.AreEqual(t.ID, 10);
        }

        [Test]
        public void TestIme()
        {
            var t = new Potrosac();
            t.Ime = "ime";

            Assert.AreEqual(t.Ime, "ime");
        }

        [Test]
        public void TestPotrosnja()
        {
            var t = new Potrosac();
            t.Potrosnja = 195.3;

            Assert.AreEqual(t.Potrosnja, 195.3);
        }

        [Test]
        public void TestIDNotValid()
        {
            var t = new Potrosac();
            t.ID = 10;

            Assert.AreNotEqual(t.ID, 11);
        }

        [Test]
        public void TestImeNotValid()
        {
            var t = new Potrosac();
            t.Ime = "ime";

            Assert.AreNotEqual(t.Ime, "imee");
        }

        [Test]
        public void TestPotrosnjaNotValid()
        {
            var t = new Potrosac();
            t.Potrosnja = 195.3;

            Assert.AreNotEqual(t.Potrosnja, 125.3);
        }

        [Test]
        public void TestUpaljenValid()
        {
            var t = new Potrosac();
            t.Upaljen = true;

            Assert.AreEqual(t.Upaljen, true);
        }

        [Test]
        public void TestUgasenValid()
        {
            var t = new Potrosac();
            t.Upaljen = false;

            Assert.AreEqual(t.Upaljen, false);
        }

        [Test]
        public void TestUpaljenInvalid()
        {
            var t = new Potrosac();
            t.Upaljen = true;

            Assert.AreNotEqual(t.Upaljen, false);
        }

        [Test]
        public void TestUgasenInvalid()
        {
            var t = new Potrosac();
            t.Upaljen = false;

            Assert.AreNotEqual(t.Upaljen, true);
        }


    }
}
