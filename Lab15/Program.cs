using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Lab15_Work
{
    public class Node
    {
        public int id;
        public List<Node> edges;
        public List<int> values;

        public float x;
        public float y;

        public Node(int id, float x, float y)
        {
            edges = new List<Node>();
            values = new List<int>();
            this.id = id;
            this.x = x;
            this.y = y;
        }
        public void AddEdge(Node node, int value)
        {
            if (!edges.Contains(node))
            {
                edges.Add(node);
                values.Add(value);
                node.edges.Add(this);
                node.values.Add(value);
            }
        }

        public void RemoveEdge(Node node)
        {
            if(edges.Contains(node))
            {
                values.RemoveAt(edges.IndexOf(node));
                edges.Remove(node);
                node.values.RemoveAt(node.edges.IndexOf(this));
                node.edges.Remove(this);
            }
        }
    }
    public class Graph
    {
        public List<Node> Verts;
        public List<KeyValuePair<Node, Node>> MinSpan;
        public List<Node> Checked = new List<Node>();

        public Graph()
        {
            Verts = new List<Node>();
            MinSpan = new List<KeyValuePair<Node, Node>>();
        }

        public Graph(string path)
        {
            Verts = new List<Node>();
            MinSpan = new List<KeyValuePair<Node, Node>>();
            StreamReader input = new StreamReader(path);
            for (int i = 0; i < System.IO.File.ReadAllLines(path).Length; i++)
            {
                string[] str = input.ReadLine().Split('|');
                Node n = new Node(int.Parse(str[0]), int.Parse(str[1]), int.Parse(str[2]));
                Verts.Add(n);
            }
            input.Close();
            input = new StreamReader(path);
            for (int i = 0; i < Verts.Count; i++)
            {
                string[] edgs = input.ReadLine().Split('|')[3].Split(',');
                for(int j = 0; j < edgs.Count()-1; j++)
                {
                    string[] b = edgs[j].Split('-');
                    Verts[i].AddEdge(FindById(int.Parse(b[0])), int.Parse(b[1]));
                }
            }
            input.Close();
        }

        public void AddVertex(float x, float y)
        {
            int new_id = 0;
            bool found = false;
            for (int i = 0; i < Verts.Count; i++)
            {
                if (!found)
                {
                    found = true;
                    foreach (Node node in Verts)
                    {
                        if (node.id == new_id)
                        {
                            new_id++;
                            found = false;
                            break;
                        }
                    }
                }
            }
            Verts.Add(new Node(new_id, x, y));
        }

        public void RemoveVertex(Node node)
        {
            while(node.edges.Count != 0)
            {
                node.RemoveEdge(node.edges[0]);
            }
            Verts.Remove(node);
        }

        public void AddEdge(Node node1, Node node2, int value)
        {
            node1.AddEdge(node2, value);
        }

        public void RemoveEdge(Node node1, Node node2)
        {
            node1.RemoveEdge(node2);
        }

        public void FindMinSpan2()
        {
            MinSpan = new List<KeyValuePair<Node, Node>>();
            List<KeyValuePair<Node, Node>> all = new List<KeyValuePair<Node, Node>>();
            KeyValuePair<Node, Node> edge = new KeyValuePair<Node, Node>(null, null);
            foreach (Node node in Verts)
            {
                foreach(Node n in node.edges)
                {
                    all.Add(new KeyValuePair<Node, Node>(node, n));
                }
            }
            int value;
            while(all.Count != 0)
            {
                value = int.MaxValue;
                edge = new KeyValuePair<Node, Node>(null, null);
                foreach (Node node in Verts)
                {
                    for (int j = 0; j < node.edges.Count; j++)
                    {
                        if (node.values[j] < value)
                        {
                            if (all.Contains(new KeyValuePair<Node, Node>(node, node.edges[j])))
                            {
                                value = node.values[j];
                                edge = new KeyValuePair<Node, Node>(node, node.edges[j]);
                            }
                        }
                    }
                }
                if (edge.Key != null) {
                    MinSpan.Add(edge);
                    all.Remove(edge);
                    edge = new KeyValuePair<Node, Node>(edge.Value, edge.Key);
                    MinSpan.Add(edge);
                    all.Remove(edge);
                }
                bool cycle = false;
                bool changed = false;
                KeyValuePair<Node, Node> next = new KeyValuePair<Node, Node>(null, null);
                List<KeyValuePair<Node, Node>> cycler;
                foreach (KeyValuePair<Node, Node> minedge in MinSpan)
                {
                    cycler = new List<KeyValuePair<Node, Node>>();
                    next = minedge;
                    cycler.Add(next);
                    do
                    {
                        changed = false;
                        foreach (KeyValuePair<Node, Node> nextedge in MinSpan)
                        {
                            if (next.Value == nextedge.Key && !(next.Key == nextedge.Value && next.Value == nextedge.Key))
                            {
                                if (cycler.Contains(nextedge) || nextedge.Value == minedge.Key) { cycle = true; break; }
                                else {
                                    cycler.Add(nextedge);
                                    changed = true;
                                }
                                next = nextedge;
                                break;
                            }
                        }
                    } while (changed && !cycle);
                    if (cycle)
                    {
                        MinSpan.RemoveAt(MinSpan.Count - 1);
                        MinSpan.RemoveAt(MinSpan.Count - 1);
                        break;
                    }
                }
            }
            int bruh = MinSpan.Count;
            for (int i = 0; i < bruh/2; i++)
            {
                MinSpan.RemoveAt(i);
            }
        }

        public void SaveToFile(string path)
        {
            StreamWriter output = new StreamWriter(path);
            foreach (Node node in Verts) {
                output.Write(node.id + "|" + node.x + "|" + node.y + "|");
                for(int i = 0; i < node.edges.Count; i++)
                {
                    output.Write(node.edges[i].id + "-" + node.values[i] + ",");
                }
                output.Write("\n");
            }
            output.Close();
        }

        public Node FindById(int id)
        {
            foreach(Node node in Verts)
            {
                if (node.id == id) return node;
            }
            return null;
        }

    }
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
