using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Classes_VR_CardConcepts;

namespace Classes_VR_UnitTests
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void TestMethod1()
        {
            Deck d1 = new Deck();
            Hand h1 = new Hand();
            for(int i = 0; i < 5; i++)
            {
                h1.add(d1.deal());
            }
            Console.WriteLine(h1.ToString());
        }
    }
}
