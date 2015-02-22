using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Classes_VR_CardConcepts;

namespace Classes_VR_UnitTests
{
    [TestClass]
    public class UnitTest4
    {
        [TestMethod]
        public void TestMethod1()
        {
            Card c1 = new Card(Count.Ace, Suit.Hearts);
            Assert.AreEqual(1, c1.BJvalue());
        }

        [TestMethod]
        public void TestMethod2()
        {
            Card c1 = new Card(Count.Two, Suit.Hearts);
            Assert.AreEqual(2, c1.BJvalue());
        }

        [TestMethod]
        public void TestMethod3()
        {
            Card c1 = new Card(Count.Three, Suit.Hearts);
            Assert.AreEqual(3, c1.BJvalue());
        }

        [TestMethod]
        public void TestMethod4()
        {
            Card c1 = new Card(Count.Four, Suit.Hearts);
            Assert.AreEqual(4, c1.BJvalue());
        }

        [TestMethod]
        public void TestMethod5()
        {
            Card c1 = new Card(Count.Five, Suit.Hearts);
            Assert.AreEqual(5, c1.BJvalue());
        }

        [TestMethod]
        public void TestMethod6()
        {
            Card c1 = new Card(Count.Six, Suit.Hearts);
            Assert.AreEqual(6, c1.BJvalue());
        }

        [TestMethod]
        public void TestMethod7()
        {
            Card c1 = new Card(Count.Seven, Suit.Hearts);
            Assert.AreEqual(7, c1.BJvalue());
        }

        [TestMethod]
        public void TestMethod8()
        {
            Card c1 = new Card(Count.Eight, Suit.Hearts);
            Assert.AreEqual(8, c1.BJvalue());
        }

        [TestMethod]
        public void TestMethod9()
        {
            Card c1 = new Card(Count.Nine, Suit.Hearts);
            Assert.AreEqual(9, c1.BJvalue());
        }

        [TestMethod]
        public void TestMethod10()
        {
            Card c1 = new Card(Count.Ten, Suit.Hearts);
            Assert.AreEqual(10, c1.BJvalue());
        }

        [TestMethod]
        public void TestMethod11()
        {
            Card c1 = new Card(Count.Jack, Suit.Hearts);
            Assert.AreEqual(10, c1.BJvalue());
        }

        [TestMethod]
        public void TestMethod12()
        {
            Card c1 = new Card(Count.Queen, Suit.Hearts);
            Assert.AreEqual(10, c1.BJvalue());
        }

        [TestMethod]
        public void TestMethod13()
        {
            Card c1 = new Card(Count.King, Suit.Hearts);
            Assert.AreEqual(10, c1.BJvalue());
        }
    }
}
