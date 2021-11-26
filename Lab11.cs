using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    abstract class Array
    {
        protected int N;
        protected int[] Arr;

        public virtual void Init(int min, int max)
        {
            Random r = new Random();
            for(int i = 0; i < N; i++)
            {
                Arr[i] = r.Next(min, max);
            }
        }

        public abstract int Calc();
        public abstract void PrintArray();
        public abstract void Processing();
    }

    class Vector : Array
    {
        Vector()
        {
            N = 30;
            Arr = new int[N];
            Init(-50, 50);
        }

        public override int Calc()
        {
            int q = 0;
            for(int i = 0; i < N; i++)
            {
                if (Arr[i] > 0) q++;
            }
            return q / 2;
        }

        public override void PrintArray()
        {
            for (int i = 0; i < N; i++) Console.Write(Arr[i] + "\t");
        }

        public override void Processing()
        {
            int x = -1, y = N, t = -1;
            for (int i = 0; i < Calc() / 2; i++)
            {
                for (int j = x + 1; j < N; j++)
                {
                    if (Arr[j] > 0) { x = j; break; }
                }
                for (int j = y - 1; j > 0; j--)
                {
                    if (Arr[j] > 0) { y = j; break; }
                }
                t = Arr[x];
                Arr[x] = Arr[y];
                Arr[y] = t;
            }
        }
    }

    class Matrix : Array
    {
        protected int W;
        protected int M;

        Matrix()
        {
            W = 5;
            M = 14;
            N = W * M;
            Arr = new int[N];
            Init(-10, 6);
        }

        public override int Calc()
        {
            int sum = 0;
            for (int i = 0; i < N; i++)
            {
                sum += Arr[i] * (int)Math.Pow((-1), i/M);
            }
            return sum;
        }

        public override void PrintArray()
        {
            for(int i = 0; i < N; i++)
            {
                Console.Write(Arr[i] + (i % M == M - 1 ? "\n" : "\t"));
            }
        }

        public override void Processing()
        {
            int min;
            for(int i = 0; i < W; i++)
            {
                min = Arr[i * M];
                for(int j = 0; j < M; j++)
                {
                    if (Arr[i * M + j] < min) min = Arr[i * M + j];
                }
                if(min > 0)
                {
                    for (int j = 0; j < M; j++) Arr[i * M + j] += min;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
