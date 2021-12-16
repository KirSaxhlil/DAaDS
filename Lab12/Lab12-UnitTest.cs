using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab12;
using System;
using System.IO;

namespace Lab12Test
{
    [TestClass]
    public class UnitTest1
    {
        StreamWriter output = new FileInfo("test.log").AppendText();
        [TestMethod]
        public void EditTest()
        {
            ProgLib test = new ProgLib();
            AppliedProg obj = new AppliedProg("NAME", 0, "LANG", "POINT", "CATEGORY");
            test.Add(obj);
            string new_value = "NEW NAME";
            output.Write("[{0}]: EditTest() asserting [{1}, {2}]; ", DateTime.Now, new_value, "test.list[0].name");
            test.Edit(0, 1, new_value);
            try { 
                Assert.AreEqual(new_value, test.list[0].name);
                output.Write("Test passed.\n");
            }
            catch (AssertFailedException) {
                output.Write("Test not passed.\n");
                throw new AssertFailedException();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void EditExceptionTest()
        {
            ProgLib test = new ProgLib();
            AppliedProg obj = new AppliedProg("NAME", 0, "LANG", "POINT", "CATEGORY");
            test.Add(obj);
            string new_value = "NEW NAME";
            output.Write("[{0}]: EditExceptionTest() editing field {1} to {2}; ", DateTime.Now, 2, new_value);
            try {
                test.Edit(0, 2, new_value);
                output.Write("Exception not throwed.\n");
            }
            catch(FormatException) {
                output.Write("Exception throwed.\n");
                throw new FormatException();
            }
        }

        ~UnitTest1(){
            output.Close();
        }
    }
}
