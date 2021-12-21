using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lab15_Work;
using System.Collections.Generic;

namespace Lab15_UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Form1 form = new Form1();
            Graph graph = new Graph("G.grf");
            graph.FindMinSpan2();
            List<KeyValuePair<Node, Node>> MinSpan = new List<KeyValuePair<Node, Node>>();
            MinSpan.Add(new KeyValuePair<Node, Node>(graph.Verts[2], graph.Verts[0]));
            MinSpan.Add(new KeyValuePair<Node, Node>(graph.Verts[2], graph.Verts[1]));
            MinSpan.Add(new KeyValuePair<Node, Node>(graph.Verts[3], graph.Verts[1]));
            MinSpan.Add(new KeyValuePair<Node, Node>(graph.Verts[4], graph.Verts[0]));
            CollectionAssert.AreEqual(MinSpan, graph.MinSpan);
            Assert.AreEqual(MinSpan.Count, graph.MinSpan.Count);
        }
    }
}
