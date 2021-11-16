using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    class Array
    {
        private int n;
        private int[] array;

        public Array()
        {
            n = 30;
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
                for (int j = x + 1; j < n; j++)
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
                Console.Write("{0} ", i);
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Array ar0 = new Array();
            Console.WriteLine("Массив ar0 с заданной длиной с нулевыми элементами:");
            ar0.Print();
            Console.WriteLine();
            Array ar1;
            try
            {
                ar1 = new Array(Convert.ToInt32(Console.ReadLine()), -10, 10);
            } catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                ar0 = null;
                ar1 = null;
                return;
            }
            Console.WriteLine("Массив ar1 с длиной, вводимой с клавиатуры и случайными числами в заданном диапазоне:");
            ar1.Print();
            Console.WriteLine();
            Array arN = new Array(ar1);
            Console.WriteLine("Копирование массива ar1 в новый массив arN:");
            arN.Print();
            Console.WriteLine();
            ar1.Edit(-5, 4653);
            ar1.Edit(5, 75);
            Console.WriteLine("Модификация произвольных элементов массива ar1:");
            ar1.Print();
            Console.WriteLine();
            arN.Process();
            Console.WriteLine("Обработка массива arN:");
            arN.Print();
            Console.WriteLine();
            Console.ReadKey();
            ar0 = null;
            ar1 = null;
            arN = null;
        }
    }
}
