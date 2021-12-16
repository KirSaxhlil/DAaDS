using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab11;
using System;

namespace ArrayTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestVectorCalc()
        {
            Vector V = new Vector();
            int expected = 7;
            int result = V.Calc();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMatrixCalc()
        {
            Matrix M = new Matrix();
            int expected = 5;
            int result = M.Calc();
            Assert.AreEqual(expected, result);
        }
    }
}
