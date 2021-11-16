using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    class Array
    {
        protected int n;
        private int[] array;

        public int this[int index]
        {
            get { return array[index]; }
            set { array[index] = value; }
        }

        public Array()
        {
            n = 10;
            array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = 0;
            }
        }

        public Array(int n, int min, int max, int seed)
        {
            this.n = n;
            array = new int[n];
            Random rnd = new Random(seed);
            for (int i = 0; i < n; i++)
            {
                array[i] = rnd.Next(min, max);
            }
        }

        public Array(Array array)
        {
            n = array.n;
            this.array = new int[n];
            for (int i = 0; i < n; i++)
            {
                this.array[i] = array.array[i];
            }
        }

        ~Array()
        {
            array = null;
        }

        public void Edit(int i, int value)
        {
            try
            {
                array[i] = value;
            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Process()
        {
            int q_pos = 0, x = -1, y = n, t = 0;
            foreach (int i in array)
            {
                if (i > 0) q_pos++;
            }
            for (int i = 0; i < q_pos / 2; i++)
            {
                for (int j = x + 1; j < 30; j++)
                {
                    if (array[j] > 0) { x = j; break; }
                }
                for (int j = y - 1; j > 0; j--)
                {
                    if (array[j] > 0) { y = j; break; }
                }
                t = array[x];
                array[x] = array[y];
                array[y] = t;
            }
        }

        public void Print()
        {
            foreach (int i in array)
            {
                Console.Write("{0,5} ", i);
            }
            Console.WriteLine();
        }

        public int Min
        {
            get
            {
                int min = array[0];
                for (int i = 1; i < n; i++)
                {
                    if (min > array[i]) min = array[i];
                }
                return min;
            }
        }
    }

    class Matrix : Array
    {
        int h;
        Array[] matrix;

        public int H
        {
            get { return h; }
        }
        public Matrix()
        {
            h = 5;
            n = 10;
            matrix = new Array[h];
            for (int i = 0; i < h; i++)
            {
                matrix[i] = new Array();
            }
            Console.WriteLine("Конструктор выполнен.");
        }

        public Matrix(int h, int n, int min, int max)
        {
            this.h = h;
            this.n = n;
            matrix = new Array[h];
            for (int i = 0; i < h; i++)
            {
                matrix[i] = new Array(n, min, max, (int)DateTime.Now.Ticks + i);
            }
            Console.WriteLine("Конструктор выполнен.");
        }

        public void Print_M()
        {
            for (int i = 0; i < h; i++)
            {
                matrix[i].Print();
            }
        }

        public int P
        {
            get
            {
                int sum = 0;
                for (int i = 0; i < h; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        sum += matrix[i][j] * (int)Math.Pow((-1), i);
                    }
                }
                return sum;
            }
        }


        public static Matrix operator +(Matrix a, int i)
        {
            int min = 0;
            try
            {
                min = a.matrix[i].Min;
            } catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                return a;
            }
            for (int j = 0; j < a.n; j++)
            {
                if (min > 0)
                    a.matrix[i][j] += min;
            }
            return a;
        }

        public void Sort()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 1; j < h; j++)
                {
                    for (int k = j; k >= 1; k--)
                    {
                        if (matrix[k][i] < matrix[k - 1][i])
                        {
                            int temp = matrix[k][i];
                            matrix[k][i] = matrix[k - 1][i];
                            matrix[k - 1][i] = temp;
                        }
                        else break;
                    }
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Matrix T0 = new Matrix();
            Console.WriteLine("Нулевая матрица фиксированного размера:");
            T0.Print_M();
            Matrix T;
            try
            {
                T = new Matrix(5, 14, -10, 5);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                T0 = null;
                T = null;
                return;
            }
            Console.WriteLine("Матрица случайных чисел:");
            T.Print_M();
            Console.WriteLine("\nПараметр Р: "+T.P);
            for (int i = 0; i < T.H; i++)
            {
                T += i;
            }
            Console.WriteLine("Матрица случайных чисел после заданного преобразования:");
            T.Print_M();
            T.Sort();
            Console.WriteLine("Матрица случайных чисел после сортировки:");
            T.Print_M();
            Console.ReadKey();
        }
    }
}
