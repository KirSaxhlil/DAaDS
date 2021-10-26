using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Array
    {
        protected int n;
        int[] array;

        public int this[int index]
        {
            get { return array[index]; }
            set { array[index] = value; }
        }

        public Array()
        {
            n = 100;
            array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = 0;
            }
            Console.WriteLine("Конструктор выполнен.");
        }

        public Array(int n, int min, int max)
        {
            this.n = n;
            array = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = rnd.Next(min, max);
            }
            Console.WriteLine("Конструктор выполнен.");
        }

        public Array(Array array)
        {
            n = array.n;
            this.array = new int[n];
            for (int i = 0; i < n; i++)
            {
                this.array[i] = array.array[i];
            }
            Console.WriteLine("Конструктор выполнен.");
        }

        ~Array()
        {
            array = null;
            Console.WriteLine("Деструктор выполнен.");
        }

        public void Edit(int i, int value)
        {
            array[i] = value;
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

        public virtual void Print()
        {
            Console.WriteLine();
            foreach (int i in array)
            {
                Console.Write("{0} ", i);
            }
        }

        public int Min
        {
            get
            {
                int min = array[0];
                for(int i = 1; i < n; i++)
                {
                    if (min < array[i]) min = array[i];
                }
                return min;
            }
        }

        bool Correct()
        {
            bool res = true;
            for (int i = 1; i < n; i++)
            {
                if (array[i] < array[i - 1]) res = false;
            }
            return res;
        }

        void Shuffle()
        {
            Random rnd = new Random();
            int i, j, t;
            for (i = 0; i < n; i++)
            {
                j = rnd.Next(0, n);
                t = array[i];
                array[i] = array[j];
                array[j] = t;
            }
        }

        public void Bogosort()
        {
            while (!Correct())
            {
                Shuffle();
            }
        }
    }

    class Matrix : Array
    {
        int h;
        Array[] matrix;

        public Matrix()
        {
            h = 10;
            n = 10;
            matrix = new Array[h];
            for (int i = 0; i < h; i++)
            {
                matrix[i] = new Array();
            }
        }

        public Matrix(int h, int n, int min, int max)
        {
            this.h = h;
            this.n = n;
            matrix = new Array[h];
            for (int i = 0; i < h; i++)
            {
                matrix[i] = new Array(n, min, max);
            }
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
            get {
                int sum = 0;
                for (int i = 0; i < h; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        sum += matrix[i][j] * (int)Math.Pow((-1), i); // pizda ubrat nado
                    }
                }
                return sum;
            }
        }

        
        public static Matrix operator +(Matrix a, int i)
        {
            int min = a.matrix[i].Min;
            for(int j = 0; j < a.n; j++)
            {
                a.matrix[i][j] += min;
            }
            return a;
        }

        public void Sort()
        {
            for(int i = 0; i < h; i++)
            {
                for(int j = 1; j < n; j++)
                {
                    for(int k = j; k >= 0 ; k--)
                    {
                        if (matrix[i][k] > matrix[i][j]) continue;
                        else if(k + 1 < j)
                        {
                            int temp = matrix[i][j];
                            matrix[i][j] = matrix[i][k + 1];
                            matrix[i][k + 1] = temp;
                        }
                    }
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Matrix m = new Matrix(10, 10, -10, 10);
            m.Print_M();
            m.Sort();
            Console.WriteLine();
            m.Print_M();
            Console.ReadKey();
        }
    }
}
