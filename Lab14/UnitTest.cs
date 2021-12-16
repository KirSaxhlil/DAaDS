using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lab14;
using System.IO;

namespace Lab14_UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TreeProcessingTest()
        {
            StreamReader input = new StreamReader("tree.res");
            string[] nums = input.ReadLine().Split(' ');
            string res = input.ReadLine();
            BinaryTree tree = new BinaryTree();
            for (int i = 0; i < nums.Length; i++) tree.Add(int.Parse(nums[i]));
            tree.Processing(tree.root);
            Assert.AreEqual(res, tree.Inorder(tree.root));
        }
    }
}
