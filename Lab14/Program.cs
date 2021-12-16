using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Lab14
{
    public class BinaryTreeNode
    {
        public BinaryTreeNode Left;
        public BinaryTreeNode Right;
        public int value;

        public BinaryTreeNode(int value)
        {
            this.value = value;
            Left = Right = null;
        }

        public bool IsLeaf()
        {
            return (Left == Right) && (Left == null);
        }
    }
    public class BinaryTree
    {
        public BinaryTreeNode root;

        public void Add(int node)
        {
            Add(new BinaryTreeNode(node), root);
        }

        public void Delete(int node)
        {
            BinaryTreeNode delParent = FindParent(node, root, root);
            BinaryTreeNode deletable = Find(node, root);
            bool side = delParent.Right == deletable;
            if (deletable.Right == null && deletable.Left == null) replace(null, delParent, side);
            else if (deletable.Right != null && deletable.Left == null) replace(deletable.Right, delParent, side);
            else if (deletable.Right == null && deletable.Left != null) replace(deletable.Left, delParent, side);
            else
            {
                BinaryTreeNode left = deletable.Right;
                while (left.Left != null) left = left.Left;
                left.Right = deletable.Right;
                left.Left = deletable.Left;
                replace(left, delParent, side);
            }
        }

        public void Draw(Pen treePen, Graphics g, float width, float yStep)
        {
            DrawIteration(treePen, g, width, root, 1, width/2, yStep);
        }

        public void Processing(BinaryTreeNode node)
        {
            if (node.Left != null)
                if (node.Left.IsLeaf())
                    node.Left = null;
                else Processing(node.Left);
            if(node.Right != null) Processing(node.Right);
        }

        public bool[] NegaLevels(BinaryTreeNode node, int lvl)
        {
            bool[] lvls = null;
            if(node != null)
            {
                lvls = Program.Combine(NegaLevels(node.Left, lvl+1), NegaLevels(node.Right, lvl+1));
                if (node.value < 0) lvls[lvl] = true;
                return lvls;
            }
            else
            {
                int N = levels(root);
                lvls = new bool[N];
                for (int i = 0; i < N; i++) lvls[i] = false;
                return lvls;
            }
        }

        public string Inorder(BinaryTreeNode node)
        {
            if (node != null)
            {
                return ((node.Left != null) ? (Inorder(node.Left) + " ") : "") + node.value + ((node.Right != null) ? (" " + Inorder(node.Right)) : "");
            }
            else return "";
        }

        int levels(BinaryTreeNode node)
        {
            if (node == null)
                return 0;

            int h_l = levels(node.Left);
            int h_r = levels(node.Right);

            return Math.Max(h_l, h_r) + 1;
        }

        void DrawIteration(Pen treePen, Graphics g, float width, BinaryTreeNode node, int level, float x, float yStep)
        {
            if(node != null)
            {
                if(node.Left != null)
                {
                    g.DrawLine(treePen, x, yStep * level, x - width / (float)(Math.Pow(2,(level+1))), yStep * (level+1) );
                    DrawIteration(treePen, g, width, node.Left, level+1, x - width / (float)(Math.Pow(2,(level+1))), yStep);
                }
                if(node.Right != null)
                {
                    g.DrawLine(treePen, x , yStep * level, x + width / (float)(Math.Pow(2,(level+1))), yStep * (level + 1));
                    DrawIteration(treePen, g, width, node.Right, level + 1, x + width / (float)(Math.Pow(2,(level+1))), yStep);
                }
                RectangleF r = new RectangleF(x - 15, yStep * level - 15, 30, 30);
                g.DrawEllipse(treePen, r);
                g.FillEllipse(Brushes.White, r);
                StringFormat SF = new StringFormat();
                SF.Alignment = StringAlignment.Center;
                SF.LineAlignment = StringAlignment.Center;
                g.DrawString(node.value.ToString(), new Font("Arial", 16), Brushes.Black, x, yStep * level, SF);
                
            }
        }

        void replace(BinaryTreeNode towhat, BinaryTreeNode where, bool side)
        {
            if (side == true) where.Right = towhat;
            else where.Left = towhat;
        }

        void Add(BinaryTreeNode node, BinaryTreeNode _current)
        {
            if (root != null)
            {
                if (node.value > _current.value)
                    if (_current.Right != null) Add(node, _current.Right);
                    else _current.Right = node;
                else if (node.value < _current.value)
                    if (_current.Left != null) Add(node, _current.Left);
                    else _current.Left = node;
            }
            else root = node;
        }

        BinaryTreeNode Find(int value, BinaryTreeNode _current)
        {
            if (_current != null)
            {
                if (value > _current.value) return Find(value, _current.Right);
                else if (value < _current.value) return Find(value, _current.Left);
                else return _current;
            }
            else return null;
        }

        BinaryTreeNode FindParent(int value, BinaryTreeNode _current, BinaryTreeNode _parent)
        {
            if (_current != null)
            {
                if (value > _current.value) return FindParent(value, _current.Right, _current);
                else if (value < _current.value) return FindParent(value, _current.Left, _current);
                else return _parent;
            }
            else return null;
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

        public static bool[] Combine(bool[] A, bool[] B)
        {
            int N = A.Length;
            bool[] C = new bool[N];
            for(int i = 0; i < N; i++)
            {
                C[i] = A[i] || B[i];
            }
            return C;
        }
    }
}
