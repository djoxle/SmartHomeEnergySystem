using NUnit.Framework;
using Solar_panel_s_;
using Solar_panel_s_.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    [TestFixture]
    public class SolarniPanelTest
    {
        [Test]
        public void TestID()
        {
            var t = new SolarniPanel();
            t.ID = 10;

            Assert.AreEqual(t.ID, 10);
        }

        [Test]
        [TestCase("monokristalni")]
        public void TestIme(string ime)
        {
            var t = new SolarniPanel();
            t.ImeSolarnogPanela = ime;

            Assert.AreEqual(t.ImeSolarnogPanela, ime);
        }


        [Test]
        [TestCase(null)]
        public void TestImeBad(string ime)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var t = new SolarniPanel();
                t.ImeSolarnogPanela = ime;
            });
        }

        [Test]
        public void TestMaxSnaga()
        {
            var t = new SolarniPanel();
            t.MaksimalnaSnagaSolarnogPanela = 100.53;

            Assert.AreEqual(t.MaksimalnaSnagaSolarnogPanela, 100.53);
        }

        [Test]
        public void TestGenerisanaSnaga()
        {
            var t = new SolarniPanel();
            t.GenerisanaSnaga = 120.53;

            Assert.AreEqual(t.GenerisanaSnaga, 120.53);
        }

        [Test]
        public void TestTip()
        {
            var t = new SolarniPanel();
            t.TipSolarnogPanelaProperty = "monokristalni";

            Assert.AreEqual(t.TipSolarnogPanelaProperty, "monokristalni");
        }
    }
}
