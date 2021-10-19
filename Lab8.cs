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
            for(int i = 0; i < n; i++)
            {
                array[i] = 0;
            }
        }

        public Array(int n, int min, int max)
        {
            this.n = n;
            array = new int[n];
            Random rnd = new Random();
            for(int i = 0; i < n; i++)
            {
                array[i] = rnd.Next(min, max);
            }
        }

        public Array(Array array)
        {
            n = array.n;
            this.array = new int[n];
            for(int i = 0; i < n; i++)
            {
                this.array[i] = array.array[i];
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
            for(int i = 1; i < n; i++)
            {
                if (array[i] < array[i - 1]) res = false;
            }
            return res;
        }

        void Shuffle()
        {
            Random rnd = new Random();
            int i, j, t;
            for(i = 0; i < n; i++)
            {
                j = rnd.Next(0, n);
                t = array[i];
                array[i] = array[j];
                array[j] = t;
            }

            

        }

        public void Bogosort()
        {
            while(!Correct())
            {
                Shuffle();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Array ar = new Array(13, 1, 100);
            ar.Print();
            Console.ReadKey();
            ar.Bogosort();
            ar.Print();
            Console.ReadKey();
        }
    }
}
