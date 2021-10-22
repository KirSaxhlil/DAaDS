using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Array
    {
        int n;
        int[] array;

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

        public void Print()
        {
            Console.WriteLine();
            foreach (int i in array)
            {
                Console.Write("{0} ", i);
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
            matrix = new Array[h];
            for(int i = 0; i < h; i++)
            {
                matrix[i] = new Array();
            }
        }

        public Matrix(int h, int n, int min, int max)
        {
            this.h = h;
            matrix = new Array[h];
            for(int i = 0; i < h; i++)
            {
                matrix[i] = new Array(n, min, max);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Array ar0 = new Array();
            ar0.Print();
            Console.WriteLine();
            Array ar1 = new Array(Convert.ToInt32(Console.ReadLine()), -10, 10);
            ar1.Print();
            Console.WriteLine();
            Array arN = new Array(ar1);
            arN.Print();
            Console.WriteLine();
            ar1.Edit(2, 4653);
            ar1.Edit(5, 75);
            ar1.Print();
            Console.WriteLine();
            arN.Process();
            arN.Print();
            Console.WriteLine();
            Console.ReadKey();
            ar0 = null;
            ar1 = null;
            arN = null;
            GC.Collect();
            Console.ReadKey();
        }
    }
}
