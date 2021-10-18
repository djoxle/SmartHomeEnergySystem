using NUnit.Framework;
using RES_projekat_5.Model;
using RES_projekat_5.Pomocna_Vreme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    [TestFixture]
    public class VremeTest
    {
        [Test]
        [TestCase(54, 10, 3)]
        [TestCase(23, 14, 1)]
        public void TestVremeGood(int sekunde, int minuti, int sati)
        {
            Vreme v = new Vreme(sekunde, minuti, sati);
            Assert.AreEqual(v.Sekunde, sekunde);
            Assert.AreEqual(v.Minuti, minuti);
            Assert.AreEqual(v.Sati, sati);

        }

        #region Sekunde seteri
        [Test]
        [TestCase(5)]
        public void SetSekunde(int sekunde)
        {
            Vreme v = new Vreme(sekunde, 1, 1);
            v.Sekunde = sekunde;
            Assert.AreEqual(sekunde, v.Sekunde);
        }

        [Test]
        [TestCase(60)]
        public void SetSekundePlusOne(int sekunde)
        {
            Vreme v = new Vreme(sekunde, 1, 1);
            v.Sekunde = sekunde;
            Assert.AreEqual(0, v.Sekunde);
        }
        #endregion

        #region Minuti seteri
        [Test]
        [TestCase(5)]
        public void SetMinuti(int minuti)
        {
            Vreme v = new Vreme(10,minuti,15);
            v.Minuti = minuti;
            Assert.AreEqual(minuti, v.Minuti);
        }

        [Test]
        [TestCase(60)]
        public void SetMinutiPlusOne(int minuti)
        {
            Vreme v = new Vreme(10, minuti, 15);
            v.Minuti = minuti;
            Assert.AreEqual(0, v.Minuti);
        }
        #endregion

        [Test]
        public void TestDatum()
        {
            var t = new Vreme(10,10,10);
            DateTime justDate = new DateTime(2020, 6, 14);
            t.Datum = justDate;

            Assert.AreEqual(t.Datum, justDate);
        }

        [Test]
        [TestCase(10)]
        public void GetSati(int sati)
        {
            Vreme v = new Vreme(10,10,sati);
            Assert.AreEqual(sati, v.Sati);
        }

        [Test]
        [TestCase(24)]
        public void GetSatiMinus(int sati)
        {
            Vreme v = new Vreme(10, 10, sati);
            Assert.AreEqual(0, v.Sati);
        }

        [Test]
        [TestCase(62, 20, 27)]
        [TestCase(2, 120, 27)]
        [TestCase(52, 20, 527)]
        public void TestVremeBad(int sekunde, int minuti, int sati)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Vreme vreme = new Vreme(sekunde,minuti,sati);
            }
             );
        }
    }
}
