using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Lab14
{
    public partial class Form1 : Form
    {
        BinaryTree tree;
        Pen treePen;
        Graphics g;
        public Form1()
        {
            InitializeComponent();
            treePen = new Pen(Color.Black, 2);
            g = Graphics.FromHwnd(pb_Tree.Handle);
        }

        private void btn_BuildTree_Click(object sender, EventArgs e)
        {
            try
            {
                string[] nums = tb_inputEnum.Text.Split(' ');
                tree = new BinaryTree();
                for (int i = 0; i < nums.Length; i++) tree.Add(int.Parse(nums[i]));
                g.Clear(Color.WhiteSmoke);
                tree.Draw(treePen, g, pb_Tree.Width, 50);
                SS_L_Status.Text = "Дерево успешно построено.";
            } catch(Exception ex)
            {
                SS_L_Status.Text = ex.Message;
            }
        }

        private void btn_Processing_Click(object sender, EventArgs e)
        {
            try
            {
                tree.Processing(tree.root);
                g.Clear(Color.WhiteSmoke);
                tree.Draw(treePen, g, pb_Tree.Width, 50);

                string inorder = tree.Inorder(tree.root);
                string[] str = inorder.Split(' ');
                bool bin = true;
                for (int i = 0; i < str.Length - 1; i++)
                {
                    if (int.Parse(str[i]) >= int.Parse(str[i + 1])) bin = false; break;
                }
                tb_Check.Text = bin == true ? "ДДП" : "Не ДДП";

                StreamWriter output = new StreamWriter("tree.res");
                output.WriteLine(inorder);
                output.Close();
                SS_L_Status.Text = "Обработка дерева проведена успешно.";
            }
            catch(Exception ex)
            {
                SS_L_Status.Text = ex.Message;
            }
        }

        private void btn_Value_Click(object sender, EventArgs e)
        {
            try
            {
                bool[] lvls = tree.NegaLevels(tree.root, 0);
                int q = 0;
                for (int i = 0; i < lvls.Length; i++) if (lvls[i] == true) q++;
                tb_Value.Text = q.ToString();
                SS_L_Status.Text = "Показатель вычислен успешно.";
            } catch(Exception ex)
            {
                SS_L_Status.Text = ex.Message;
            }
        }
    }
}
