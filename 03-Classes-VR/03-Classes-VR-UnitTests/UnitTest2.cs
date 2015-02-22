using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Classes_VR_CardConcepts;

namespace Classes_VR_UnitTests
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            Deck d1 = new Deck();
            for(int i = 0; i < 24; i++)
            {
                Console.WriteLine(d1.deal().ToString());
            }
        }
    }
}
