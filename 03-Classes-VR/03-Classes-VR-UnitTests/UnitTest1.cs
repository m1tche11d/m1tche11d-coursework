﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Classes_VR_CardConcepts;

namespace Classes_VR_UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Card c1 = new Card(Count.Ace, Suit.Hearts);
            Assert.AreEqual(Count.Ace, c1.count);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Card c1 = new Card(Count.Ace, Suit.Hearts);
            Assert.AreEqual(Suit.Hearts, c1.suit);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Card c1 = new Card(Count.Ace, Suit.Hearts);
            Assert.AreEqual(1, c1.BJvalue());
            Console.WriteLine(c1.ToString());
        }
    }
}
