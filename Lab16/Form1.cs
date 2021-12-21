using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace Lab16
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DrawGraph();
        }

        public double f(double x, double a, double b)
        {
            return b * Math.Pow(x, 2) - a * Math.Log10(x);
        }
        public void DrawGraph()
        {
            // Получим панель для рисования
            GraphPane pane = zedGraph.GraphPane;
            pane.XAxis.Cross = 0.0;
            pane.YAxis.Cross = 0.0;
            pane.XAxis.Scale.IsSkipFirstLabel = true;
            pane.XAxis.Scale.IsSkipLastLabel = true;
            pane.YAxis.Scale.IsSkipFirstLabel = true;
            pane.YAxis.Scale.IsSkipLastLabel = true;
            pane.YAxis.Scale.IsSkipCrossLabel = true;
            pane.XAxis.Title.IsVisible = false;
            pane.YAxis.Title.IsVisible = false;
            pane.Title.IsVisible = false;
            // Изменим тест надписи по оси X
            pane.XAxis.Title.Text = "x";
            // Изменим текст по оси Y
            pane.YAxis.Title.Text = "y";
            // Изменим текст заголовка графика
            pane.Title.Text = "График функции y = b*x^2-a*Lg(x)";
            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            pane.CurveList.Clear();
            // Создадим список точек
            PointPairList list = new PointPairList();
            double xmin = 2;
            double xmax = 7;

            double[] ymin = { 0, double.MaxValue };
            double[] ymax = { 0, double.MinValue };
            double[] xpmin = { xmin , xmin};
            double[] xpmax = { xmin , xmin};

            // Заполняем список точек
            try
            {
                for (double x = xmin; x <= xmax; x += 0.01)
                {
                    // добавим в список точку
                    double t = f(x, double.Parse(tb_A.Text), double.Parse(tb_B.Text));
                    list.Add(x, t);
                    if (t > ymax[1])
                    {
                        ymax[1] = t;
                        xpmax[0] = xpmax[1] = x;
                    }
                    if(t < ymin[1])
                    {
                        ymin[1] = t;
                        xpmin[0] = xpmin[1] = x;
                    }
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            // Создадим кривую с названием "Sinc",
            // которая будет рисоваться голубым цветом (Color.Blue),
            // Опорные точки выделяться не будут (SymbolType.None)
            pane.AddCurve("y = b*x^2-a*Lg(x)", list, Color.Blue, SymbolType.None);
            pane.AddCurve("", xpmin, ymin, Color.Red, SymbolType.None);
            pane.AddCurve("", xpmax, ymax, Color.Red, SymbolType.None);
            xpmin[0] = 0;
            xpmax[0] = 0;
            ymin[0] = ymin[1];
            ymax[0] = ymax[1];
            pane.AddCurve("", xpmin, ymin, Color.Red, SymbolType.None);
            pane.AddCurve("", xpmax, ymax, Color.Red, SymbolType.None);

            // Вызываем метод AxisChange (), чтобы обновить данные об осях.
            // В противном случае на рисунке будет показана только часть графика,
            // которая умещается в интервалы по осям, установленные по умолчанию
            zedGraph.AxisChange();

            // Обновляем график
            zedGraph.Invalidate();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            DrawGraph();
        }
        private void tb_A_TextChanged(object sender, EventArgs e)
        {
            DrawGraph();
        }
        private void tb_B_TextChanged(object sender, EventArgs e)
        {
            DrawGraph();
        }
    }
}
