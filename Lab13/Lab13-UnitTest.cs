using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lab13;

namespace Lab13_UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DelegateTest()
        {
            AppliedProg p1 = new AppliedProg("Name", 0, "lang", "point", "user");
            AppliedProg p2 = new AppliedProg("Ubername", 4, "prolang", "antipoint", "superuser");
            ProgLib.del delegat = AppliedProg.Compare_Name;
            int res = delegat(p1, p2);
            Assert.AreEqual(-1, res);
        }

        [TestMethod]
        [ExpectedException (typeof(ArgumentOutOfRangeException))]
        public void ExceptionTest()
        {
            ProgLib list = new ProgLib();
            list.Edit(7);
        }
    }
}
